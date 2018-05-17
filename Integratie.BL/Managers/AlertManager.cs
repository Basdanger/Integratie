using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL;
using Integratie.Domain;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Subjects;
using Integratie.Domain.Entities;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Integratie.BL.Managers
{
    public class AlertManager
    {
        private AlertRepo repo = new AlertRepo();
        public async Task CheckAlerts()
        {
            List<Alert> alerts = repo.GetAlerts().ToList();
            List<Alert> trueAlerts = new List<Alert>();
            foreach (Alert a in alerts)
            {
                a.Ring = false;
                if (CheckAlert(a))
                {
                    a.Ring = true;
                    trueAlerts.Add(a);
                }
            }
            await repo.UpdateAlerts(alerts);

            foreach (Alert a in trueAlerts)
            {
                MailManager mailManager = new MailManager();
                List<UserAlert> userAlerts = repo.GetUserAlertsOfAlert(a.AlertID).ToList();
                foreach (UserAlert uA in userAlerts)
                {
                    uA.Show = true;
                    if (uA.Mail)
                    {
                        await mailManager.SendMail("test",uA.Account.Mail,uA.Account.Name);
                    }
                    if (uA.App)
                    {

                    }
                }
            }
        }

        private bool CheckAlert(Alert alert)
        {
            if (alert.GetType() == typeof(CheckAlert))
            {
                return CheckCheckAlert((CheckAlert)alert);
            }
            else if (alert.GetType() == typeof(CompareAlert))
            {
                return CheckCompareAlert((CompareAlert)alert);
            }
            else if (alert.GetType() == typeof(TrendAlert))
            {
                return CheckTrendAlert((TrendAlert)alert);
            }
            else
            {
                return CheckSentimentAlert((SentimentAlert)alert);
            }
        }

        private bool CheckSentimentAlert(SentimentAlert alert)
        {
            Subject subject = alert.Subject;
            FeedManager feedManager = new FeedManager();
            IEnumerable<Feed> feeds;

            if (subject.GetType() == typeof(Person))
            {
                feeds = feedManager.GetPersonFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }
            else if (subject.GetType() == typeof(Organisation))
            {
                feeds = feedManager.GetOrganisationFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }
            else
            {
                feeds = feedManager.GetWordFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }

            int feedCount = feeds.Count();
            int posNegFeeds = 0;
            double result;

            if (alert.SubjectProperty.Equals(SubjectProperty.pos))
            {
                foreach (Feed f in feeds)
                {
                    string[] sentiment = f.Sentiment.Split(',');
                    float posneg = float.Parse(sentiment[0],System.Globalization.CultureInfo.InvariantCulture);
                    if (posneg > 0)
                    {
                        posNegFeeds++;
                    }
                }
                result = posNegFeeds / feedCount;
            }
            else
            {
                foreach (Feed f in feeds)
                {
                    string[] sentiment = f.Sentiment.Split(',');
                    float posneg = float.Parse(sentiment[0], System.Globalization.CultureInfo.InvariantCulture);
                    if (posneg < 0)
                    {
                        posNegFeeds++;
                    }
                }
                result = posNegFeeds / feedCount;
            }

            switch (alert.Operator)
            {
                case Operator.GT:
                    if (result >= alert.Value)
                    {
                        return true;
                    }
                    break;
                case Operator.LT:
                    if (result <= alert.Value)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public bool CheckCheckAlert(CheckAlert alert)
        {
            Subject subject = alert.Subject;
            FeedManager feedManager = new FeedManager();
            IEnumerable<Feed> feeds;

            if (subject.GetType() == typeof(Person))
            {
                feeds = feedManager.GetPersonFeedsSince(subject.Name,DateTime.Now.AddDays(-7));
            }
            else if (subject.GetType() == typeof(Organisation))
            {
                feeds = feedManager.GetOrganisationFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }
            else
            {
                feeds = feedManager.GetWordFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }

            int fCPast = 0;
            foreach (Feed f in feeds)
            {
                if (f.Date.Ticks < DateTime.Now.AddDays(-1).Ticks)
                {
                    fCPast++;
                }
            }

            fCPast = fCPast / 6;

            fCPast = (fCPast == 0) ? 1 : fCPast;

            int fCNow = 0;
            foreach (Feed f in subject.Feeds)
            {
                if (f.Date.Ticks >= DateTime.Now.AddDays(-1).Ticks)
                {
                    fCNow++;
                }
            }

            int result;

            if (alert.SubjectProperty.Equals(SubjectProperty.relativeCount))
            {
                result = fCNow / fCPast - 1;
            }
            else
            {
                result = fCNow - fCPast;
            }
            
            switch (alert.Operator)
            {
                case Operator.GT:
                    if (result >= alert.Value)
                    {
                        return true;
                    }
                    break;
                case Operator.LT:
                    if (result <= alert.Value)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public bool CheckCompareAlert(CompareAlert alert)
        {
            Subject subjectA = alert.SubjectA;
            Subject subjectB = alert.SubjectB;

            int fcA = 0;
            int fcB = 0;

            FeedManager feedManager = new FeedManager();
            IEnumerable<Feed> feedsA;
            IEnumerable<Feed> feedsB;

            if (subjectA.GetType() == typeof(Person))
            {
                feedsA = feedManager.GetPersonFeedsSince(subjectA.Name, DateTime.Now.AddDays(-7));
                feedsB = feedManager.GetPersonFeedsSince(subjectB.Name, DateTime.Now.AddDays(-7));
            }
            else if (subjectA.GetType() == typeof(Organisation))
            {
                feedsA = feedManager.GetOrganisationFeedsSince(subjectA.Name, DateTime.Now.AddDays(-7));
                feedsB = feedManager.GetOrganisationFeedsSince(subjectB.Name, DateTime.Now.AddDays(-7));
            }
            else
            {
                feedsA = feedManager.GetWordFeedsSince(subjectA.Name, DateTime.Now.AddDays(-7));
                feedsB = feedManager.GetWordFeedsSince(subjectB.Name, DateTime.Now.AddDays(-7));
            }

            fcA = feedsA.Count();
            fcB = feedsB.Count();

            switch (alert.Operator)
            {
                case Operator.GT:
                    if (fcA > fcB)
                    {
                        return true;
                    }
                    break;
                case Operator.LT:
                    if (fcA < fcB)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public bool CheckTrendAlert(TrendAlert alert)
        {
            Subject subject = alert.Subject;

            int days = 6;
            int fcToday = 0;
            int fcHistory = 0;
            float avarage = 0;
            float[] avarages = new float[days];
            double std = 0;
            double zScore = 0;

            FeedManager feedManager = new FeedManager();
            IEnumerable<Feed> feeds;

            if (subject.GetType() == typeof(Person))
            {
                feeds = feedManager.GetPersonFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }
            else if (subject.GetType() == typeof(Organisation))
            {
                feeds = feedManager.GetOrganisationFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }
            else
            {
                feeds = feedManager.GetWordFeedsSince(subject.Name, DateTime.Now.AddDays(-7));
            }

            foreach (Feed f in feeds)
            {
                if (f.Date.Ticks >= DateTime.Now.AddDays(-1).Ticks)
                {
                    fcToday++;
                }
            }

            for (int i = 0; i < days; i++)
            {
                foreach (Feed f in feeds)
                {
                    if (f.Date.Ticks >= DateTime.Now.AddDays(-2 - i).Ticks && f.Date.Ticks < DateTime.Now.AddDays(-1 - i).Ticks)
                    {
                        fcHistory++;
                    }
                }
                avarages[i] = fcHistory;
                avarage += fcHistory;
                fcHistory = 0;
            }

            avarage = (float)avarage / days;

            foreach (float item in avarages)
            {
                std += Math.Pow(item - avarage, 2);
            }

            std = Math.Sqrt(std / days);

            zScore = ((float)fcToday - avarage) / std;

            if (zScore > 2)
            {
                return true;
            }
            else
                return false;
        }

        public void AddUserAlert(string id, string alertType, string subject, bool web, bool mail, bool app, string subjectB, string compare, string subjectProperty, double value)
        {
            AccountManager accountManager = new AccountManager(repo.GetContext());
            Alert alert = AddAlert(subject, alertType, subjectB, compare, subjectProperty, value);
            Account account = accountManager.GetAccountById(id);
            UserAlert userAlert = new UserAlert(account, alert, web, mail, app);
            repo.AddUserAlert(userAlert);
        }

        public Alert AddAlert(string subjectName, string alertType, string subjectBName, string compare, string subjectProperty, double value)
        {
            Alert alert;
            SubjectManager subjectManager = new SubjectManager(repo.GetContext());
            Subject subject = subjectManager.GetSubjectByName(subjectName);
            Alert existingAlert;

            if (alertType.Equals("Trend"))
            {
                alert = new TrendAlert(subject);
                existingAlert = repo.FindTrendAlert((TrendAlert)alert);
            }
            else if (alertType.Equals("Compare"))
            {
                Subject subjectB = subjectManager.GetSubjectByName(subjectBName);
                Operator @operator;
                if (compare.Equals("GT"))
                {
                    @operator = Operator.GT;
                }
                else
                {
                    @operator = Operator.LT;
                }

                alert = new CompareAlert(subject, subjectB, @operator);
                existingAlert = repo.FindCompareAlert((CompareAlert)alert);
            }
            else if (alertType.Equals("Check"))
            {
                SubjectProperty property;
                if (subjectProperty.Equals("count"))
                {
                    property = SubjectProperty.count;
                }
                else
                {
                    property = SubjectProperty.relativeCount;
                }
                Operator @operator;
                if (compare.Equals("GT"))
                {
                    @operator = Operator.GT;
                }
                else
                {
                    @operator = Operator.LT;
                }

                alert = new CheckAlert(property, @operator, value, subject);
                existingAlert = repo.FindCheckAlert((CheckAlert)alert);
            }
            else
            {
                SubjectProperty property;
                if (subjectProperty.Equals("pos"))
                {
                    property = SubjectProperty.pos;
                }
                else
                {
                    property = SubjectProperty.neg;
                }
                Operator @operator;
                if (compare.Equals("GT"))
                {
                    @operator = Operator.GT;
                }
                else
                {
                    @operator = Operator.LT;
                }

                alert = new SentimentAlert(property, @operator, value, subject);
                existingAlert = repo.FindSentimentAlert((SentimentAlert)alert);
            }

            if (existingAlert != null)
            {
                alert = existingAlert;
            } else
            {
                this.Validate(alert);
                repo.AddAlert(alert);
            }
            return alert;
        }

        public IEnumerable<UserAlert> GetUserAlertsOfUser(string userId)
        {
            return repo.GetUserAlertsOfUser(userId);
        }

        private void Validate(Alert alert)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(alert, new ValidationContext(alert), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException("Ticket not valid!");
        }
    }
}
