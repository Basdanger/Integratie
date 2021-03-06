﻿using System;
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
using Newtonsoft.Json;

namespace Integratie.BL.Managers
{
    public class AlertManager
    {
        private AlertRepo repo;
        private UnitOfWorkManager unitOfWorkManager;

        public AlertManager()
        {
            repo = new AlertRepo();
        }

        public AlertManager(UnitOfWorkManager unitOfWorkManager)
        {
            this.unitOfWorkManager = unitOfWorkManager;
            repo = new AlertRepo(unitOfWorkManager.UnitOfWork);
        }

        public async Task CheckAlerts(DateTime now)
        {
            List<Alert> alerts = await repo.GetAlertsAsync();
            List<Alert> trueAlerts = new List<Alert>();
            foreach (Alert a in alerts)
            {
                if (await CheckAlert(a,now))
                {
                    trueAlerts.Add(a);
                }
            }
            await repo.UpdateAlerts(alerts);

            foreach (Alert a in trueAlerts)
            {
                FireBaseManager fireBaseManager = new FireBaseManager();
                MailManager mailManager = new MailManager();
                List<UserAlert> userAlerts = await repo.GetUserAlertsOfAlertAsync(a.AlertID);
                foreach (UserAlert uA in userAlerts)
                {
                    uA.Show = true;
                    if (uA.Mail)
                    {
                        await mailManager.SendMail("test",uA.Account.Mail,uA.Account.Name);
                    }
                    if (uA.App && uA.Account.DeviceId != null)
                    {
                        await fireBaseManager.SendNotification("test",uA.Account.DeviceId);
                    }
                }
                await repo.UpdateUserAlerts(userAlerts);
            }
        }

        private async Task<bool> CheckAlert(Alert alert,DateTime now)
        {
            if (alert.GetType() == typeof(CheckAlert))
            {
                return await CheckCheckAlert((CheckAlert)alert,now);
            }
            else if (alert.GetType() == typeof(CompareAlert))
            {
                return await CheckCompareAlert((CompareAlert)alert,now);
            }
            else if (alert.GetType() == typeof(TrendAlert))
            {
                return await CheckTrendAlert((TrendAlert)alert,now);
            }
            else
            {
                return await CheckSentimentAlert((SentimentAlert)alert,now);
            }
        }

        private async Task<bool> CheckSentimentAlert(SentimentAlert alert,DateTime now)
        {
            Subject subject = alert.Subject;
            FeedManager feedManager = new FeedManager();
            List<Feed> feeds;

            DateTime end = now;
            DateTime start = end.AddDays(-7);
            Dictionary<string, double> valuePairs = new Dictionary<string, double>();

            if (subject.GetType() == typeof(Person))
            {
                feeds = await feedManager.GetPersonFeedsSinceAsync(subject.Name, start);
            }
            else if (subject.GetType() == typeof(Organisation))
            {
                feeds = await feedManager.GetOrganisationFeedsSinceAsync(subject.Name, start);
            }
            else
            {
                feeds = await feedManager.GetWordFeedsSinceAsync(subject.Name, start);
            }

            int feedCount = feeds.Count();
            int posNegFeeds = 0;
            int result;

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
                valuePairs.Add("Positive", posNegFeeds);
                valuePairs.Add("Negative", feedCount - posNegFeeds);
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
                    valuePairs.Add("Positive", feedCount - posNegFeeds);
                    valuePairs.Add("Negative", posNegFeeds);
                }
                result = (posNegFeeds / feedCount) * 100;
            }

            alert.Graph.EndDate = end;
            alert.Graph.StartDate = start;
            alert.JsonValues = JsonConvert.SerializeObject(valuePairs);

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

        private async Task<bool> CheckCheckAlert(CheckAlert alert,DateTime now)
        {
            Subject subject = alert.Subject;
            FeedManager feedManager = new FeedManager();
            List<Feed> feeds;

            DateTime end = now;
            DateTime start = end.AddDays(-7);
            Dictionary<string, List<double>> valuePairs = new Dictionary<string, List<double>>();
            List<double> values = new List<double>();

            if (subject.GetType() == typeof(Person))
            {
                feeds = await feedManager.GetPersonFeedsSinceAsync(subject.Name,start);
            }
            else if (subject.GetType() == typeof(Organisation))
            {
                feeds = await feedManager.GetOrganisationFeedsSinceAsync(subject.Name, start);
            }
            else
            {
                feeds = await feedManager.GetWordFeedsSinceAsync(subject.Name, start);
            }

            int fCPast = 0;
            
            int fc = 0;

            for (int i = 6; i > 0; i--)
            {
                foreach (Feed f in feeds)
                {
                    if (start.AddDays(6 - i).Ticks <= f.Date.Ticks && f.Date.Ticks < end.AddDays(-i).Ticks)
                    {
                        fc++;
                    }
                }
                fCPast += fc;
                values.Add(fc);
                fc = 0;
            }

            fCPast = fCPast / 6;

            fCPast = (fCPast == 0) ? 1 : fCPast;

            int fCNow = 0;
            foreach (Feed f in feeds)
            {
                if (f.Date.Ticks >= end.AddDays(-1).Ticks)
                {
                    fCNow++;
                }
            }
            values.Add(fCNow);
            valuePairs.Add(subject.Name, values);

            int result;

            if (alert.SubjectProperty.Equals(SubjectProperty.relativeCount))
            {
                result = (fCNow / fCPast - 1) * 100;
            }
            else
            {
                result = fCNow - fCPast;
            }

            alert.Graph.EndDate = end;
            alert.Graph.StartDate = start;
            alert.JsonValues = JsonConvert.SerializeObject(valuePairs);

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

        private async Task<bool> CheckCompareAlert(CompareAlert alert,DateTime now)
        {
            Subject subjectA = alert.SubjectA;
            Subject subjectB = alert.SubjectB;

            int fcA = 0;
            int fcB = 0;

            FeedManager feedManager = new FeedManager();
            List<Feed> feedsA;
            List<Feed> feedsB;

            DateTime end = now;
            DateTime start = end.AddDays(-7);
            Dictionary<string, double> valuePairs = new Dictionary<string, double>();

            if (subjectA.GetType() == typeof(Person))
            {
                feedsA = await feedManager.GetPersonFeedsSinceAsync(subjectA.Name, start);
                feedsB = await feedManager.GetPersonFeedsSinceAsync(subjectB.Name, start);
            }
            else if (subjectA.GetType() == typeof(Organisation))
            {
                feedsA = await feedManager.GetOrganisationFeedsSinceAsync(subjectA.Name, start);
                feedsB = await feedManager.GetOrganisationFeedsSinceAsync(subjectB.Name, start);
            }
            else
            {
                feedsA = await feedManager.GetWordFeedsSinceAsync(subjectA.Name, start);
                feedsB = await feedManager.GetWordFeedsSinceAsync(subjectB.Name, start);
            }

            fcA = feedsA.Count();
            valuePairs.Add(subjectA.Name, fcA);
            fcB = feedsB.Count();
            valuePairs.Add(subjectB.Name, fcB);

            alert.Graph.EndDate = end;
            alert.Graph.StartDate = start;
            alert.JsonValues = JsonConvert.SerializeObject(valuePairs);

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

        private async Task<bool> CheckTrendAlert(TrendAlert alert,DateTime now)
        {
            Subject subject = alert.Subject;

            int days = 6;
            int fcToday = 0;
            int fcHistory = 0;
            float avarage = 0;
            double std = 0;
            double zScore = 0;

            FeedManager feedManager = new FeedManager();
            IEnumerable<Feed> feeds;

            DateTime end = now;
            DateTime start = end.AddDays(-7);
            Dictionary<string, List<double>> valuePairs = new Dictionary<string, List<double>>();
            List<double> values = new List<double>();

            if (subject.GetType() == typeof(Person))
            {
                feeds = await feedManager.GetPersonFeedsSinceAsync(subject.Name, start);
            }
            else if (subject.GetType() == typeof(Organisation))
            {
                feeds = await feedManager.GetOrganisationFeedsSinceAsync(subject.Name, start);
            }
            else
            {
                feeds = await feedManager.GetWordFeedsSinceAsync(subject.Name, start);
            }

            foreach (Feed f in feeds)
            {
                if (f.Date.Ticks >= end.AddDays(-1).Ticks)
                {
                    fcToday++;
                }
            }

            for (int i = 6; i > 0; i--)
            {
                foreach (Feed f in feeds)
                {
                    if (start.AddDays(6 - i).Ticks <= f.Date.Ticks && f.Date.Ticks < end.AddDays(-i).Ticks)
                    {
                        fcHistory++;
                    }
                }
                avarage += fcHistory;
                values.Add(fcHistory);
                fcHistory = 0;
            }

            valuePairs.Add(subject.Name, values);

            avarage = (float)avarage / days;

            foreach (float item in values)
            {
                std += Math.Pow(item - avarage, 2);
            }

            std = Math.Sqrt(std / days);

            zScore = ((float)fcToday - avarage) / std;

            alert.Graph.EndDate = end;
            alert.Graph.StartDate = start;
            alert.JsonValues = JsonConvert.SerializeObject(valuePairs);

            if (zScore > 2)
            {
                return true;
            }
            else
                return false;
        }

        public void AddUserAlert(string id, string alertType, string subject, bool web, bool mail, bool app, string subjectB, string compare, string subjectProperty, int value)
        {
            initNonExistingRepo(true);
            AccountManager accountManager = new AccountManager(unitOfWorkManager);
            Alert alert = AddAlert(subject, alertType, subjectB, compare, subjectProperty, value);
            Account account = accountManager.GetAccountById(id);
            UserAlert userAlert = new UserAlert(account, alert, web, mail, app);
            repo.AddUserAlert(userAlert);
            unitOfWorkManager.Save();
        }

        public Alert AddAlert(string subjectName, string alertType, string subjectBName, string compare, string subjectProperty, int value)
        {
            Alert alert;
            SubjectManager subjectManager = new SubjectManager(unitOfWorkManager);
            GraphManager graphManager = new GraphManager(unitOfWorkManager);
            Subject subject = subjectManager.GetSubjectByName(subjectName);
            Alert existingAlert;

            if (alertType.Equals("Trend"))
            {
                alert = new TrendAlert(subject);
                alert.Graph = graphManager.AddAlertLineGraph();
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
                alert.Graph = graphManager.AddAlertBarGraph();
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
                alert.Graph = graphManager.AddAlertLineGraph();
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
                alert.Graph = graphManager.AddAlertBarGraph();
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

        public IEnumerable<UserAlert> GetUserTrendAlertsOfUser(string userId)
        {
            return repo.GetUserTrendAlertsOfUser(userId);
        }

        public IEnumerable<UserAlert> GetUserCheckAlertsOfUser(string userId)
        {
            return repo.GetUserCheckAlertsOfUser(userId);
        }

        public IEnumerable<UserAlert> GetUserCompareAlertsOfUser(string userId)
        {
            return repo.GetUserCompareAlertsOfUser(userId);
        }

        public IEnumerable<UserAlert> GetUserSentimentAlertsOfUser(string userId)
        {
            return repo.GetUserSentimentAlertsOfUser(userId);
        }

        public UserAlert GetUserWeeklyAlert(string userId)
        {
            return repo.GetUserWeeklyAlert(userId);
        }

        public void AddUserWeeklyAlert(Account account)
        {
            UserAlert userAlert = new UserAlert(account, repo.FindWeeklyAlert(), true, false, true);
            repo.AddUserAlert(userAlert);
        }

        public Alert GetAlertById(int id)
        {
            return repo.GetAlertById(id);
        }

        public void UpdateUserAlert(int id, bool web, bool mail, bool app)
        {
            UserAlert userAlert = repo.GetUserAlert(id);
            userAlert.Web = web;
            userAlert.Mail = mail;
            userAlert.App = app;
            repo.UpdateUserAlert(userAlert);
        }

        public void RemoveUserAlert(int id)
        {
            UserAlert userAlert = repo.GetUserAlert(id);
            repo.RemoveUserAlert(userAlert);
        }

        public async Task ShowUserWeeklyAlerts()
        {
            List<UserAlert> userAlerts = repo.GetWeeklyUserAlets().ToList();
            foreach (UserAlert userAlert in userAlerts)
            {
                userAlert.Show = true;
            }

            await repo.UpdateUserAlerts(userAlerts);
        }

        public void UserAlertsViewed(string userId)
        {
            List<UserAlert> userAlerts = repo.GetUserAlertsOfUser(userId).ToList();
            userAlerts.ForEach(u => u.Show = false);
            userAlerts.ForEach(u => repo.UpdateUserAlert(u));
        }

        public void UserAlertViewed(string userId, int alertId)
        {
            UserAlert userAlert = repo.GetUserAlertByUserAndAlert(userId, alertId);
            userAlert.Show = false;
            repo.UpdateUserAlert(userAlert);
        }

        public void initNonExistingRepo(bool createWithUnitOfWork = false)
        {
            if (createWithUnitOfWork)
            {
                if (unitOfWorkManager == null)
                {
                    unitOfWorkManager = new UnitOfWorkManager();
                }
                repo = new AlertRepo(unitOfWorkManager.UnitOfWork);
            }
            else
            {
                repo = new AlertRepo();
            }
        }
    }
}
