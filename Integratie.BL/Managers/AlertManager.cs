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

namespace Integratie.BL.Managers
{
    public class AlertManager
    {
        // test
        private AlertRepo repo = new AlertRepo();
        public void CheckAlerts()
        {
            foreach (Alert a in repo.GetAlerts())
            {
                if (a.GetType() == typeof(CheckAlert))
                {
                    if (CheckCheckAlert((CheckAlert)a))
                    {
                        a.Ring = true;
                        repo.UpdateAlert(a);
                    } 
                }
                else if (a.GetType() == typeof(CompareAlert))
                {
                    if (CheckCompareAlert((CompareAlert)a))
                    {
                        a.Ring = true;
                        repo.UpdateAlert(a);
                    }
                }
                else if (a.GetType() == typeof(TrendAlert))
                {
                    if (CheckTrendAlert((TrendAlert)a))
                    {
                        a.Ring = true;
                        repo.UpdateAlert(a);
                    }
                }
            }
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

            int fCNow = 0;
            foreach (Feed f in subject.Feeds)
            {
                if (f.Date.Ticks >= DateTime.Now.AddDays(-1).Ticks)
                {
                    fCNow++;
                }
            }

            int result = fCNow / fCPast;
            switch (alert.Operator)
            {
                case Operator.EQ:
                    if (result == alert.Value)
                    {
                        return true;
                    }
                    break;
                case Operator.GT:
                    if (result > alert.Value)
                    {
                        return true;
                    }
                    break;
                case Operator.LT:
                    if (result < alert.Value)
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
                case Operator.EQ:
                    if (fcA == fcB)
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
    }
}
