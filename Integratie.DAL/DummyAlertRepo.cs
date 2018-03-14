using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Alerts;
using Integratie.Domain;

namespace Integratie.DAL
{
    public class DummyAlertRepo : IAlertRepo
    {
        List<Alert> alerts = new List<Alert>();
        public DummyAlertRepo()
        {
            //DUMMY FEEDS
            Feed F1 = new Feed(DateTime.Now, 3);
            Feed F2 = new Feed(DateTime.Now, 3);
            Feed F3 = new Feed(DateTime.Now, 3);
            Feed F4 = new Feed(DateTime.Now, 3);
            Feed F5 = new Feed(DateTime.Now, 3);
            Feed F6 = new Feed(DateTime.Now, 3);
            Feed F7 = new Feed(DateTime.Now, 3);
            Feed F8 = new Feed(DateTime.Now, 3);
            Feed F9 = new Feed(DateTime.Now, 3);
            Feed F10 = new Feed(DateTime.Now, 3);

            //DUMMY SUBJECTS
            Subject S1 = new Subject(1, "Bart De Wever");
            S1.AddFeed(F1);
            S1.AddFeed(F2);
            S1.AddFeed(F3);
            S1.AddFeed(F4);
            S1.AddFeed(F5);
            S1.AddFeed(F6);
            S1.AddFeed(F7);
            S1.AddFeed(F8);
            S1.AddFeed(F9);
            S1.AddFeed(F10);

            //DUMMY ALERTS
            CheckAlert CH1 = new CheckAlert(null,SubjectProperty.count,Operator.GT,30,S1);

            alerts.Add(CH1);
        }
        public Alert AddAlert(Alert alert)
        {
            alerts.Add(alert);
            return alerts.Last();
        }

        public Alert GetAlertById(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Alert> GetAlerts()
        {
            return alerts;
        }

        public void RemoveAlert(Alert alert)
        {
            alerts.Remove(alert);
        }
    }
}
