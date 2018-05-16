using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Alerts;

namespace Integratie.DAL.Repositories
{
    public class AlertRepo : IAlertRepo
    {
        private DashBoardDbContext context;

        public AlertRepo()
        {
            context = new DashBoardDbContext();
        }

        public DashBoardDbContext GetContext()
        {
            return context;
        }

        public void AddAlert(Alert alert)
        {
            context.Alerts.Add(alert);
            context.SaveChanges();
        }

        public void AddUserAlert(UserAlert userAlert)
        {
            context.UserAlerts.Add(userAlert);
            context.SaveChanges();
        }

        public Alert GetAlertById(int id)
        {
            return context.Alerts.Find(id);
        }

        public IEnumerable<Alert> GetAlerts()
        {
            return context.Alerts.ToList<Alert>();
        }

        public UserAlert GetUserAlert(string user, int alert)
        {
            return (UserAlert)context.UserAlerts.Where(u => u.Account.ID.Equals(user) && u.Alert.AlertID.Equals(alert));
        }

        public IEnumerable<UserAlert> GetUserAlerts()
        {
            return context.UserAlerts.ToList<UserAlert>();
        }

        public IEnumerable<UserAlert> GetUserAlertsOfAlert(int alertId)
        {
            return context.UserAlerts.Where(u => u.Alert.AlertID.Equals(alertId)).ToList<UserAlert>();
        }

        public IEnumerable<UserAlert> GetUserAlertsOfUser(string userId)
        {
            return context.UserAlerts.Where(u => u.Account.ID.Equals(userId)).ToList<UserAlert>();
        }

        public void RemoveAlert(Alert alert)
        {
            context.Alerts.Remove(alert);
        }

        public void UpdateAlert(Alert alert)
        {
            context.Entry(alert).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public async Task UpdateAlerts(List<Alert> alerts)
        {
            foreach (Alert alert in alerts)
            {
                context.Entry(alert).State = System.Data.Entity.EntityState.Modified;
            }
            await context.SaveChangesAsync();
        }

        public CheckAlert FindCheckAlert(CheckAlert alert)
        {
            CheckAlert checkAlert = null;
            try
            {
                checkAlert = context.Alerts.OfType<CheckAlert>().Where(a => a.Subject.ID.Equals(alert.Subject.ID) && a.Operator.Equals(alert.Operator) && a.SubjectProperty.Equals(alert.SubjectProperty) && a.Value.Equals(alert.Value)).First();
            }
            catch (Exception)
            {
                return checkAlert;
            }
            return checkAlert;
        }

        public SentimentAlert FindSentimentAlert(SentimentAlert alert)
        {
            SentimentAlert sentimentAlert = null;
            try
            {
                sentimentAlert = context.Alerts.OfType<SentimentAlert>().Where(a => a.Subject.ID.Equals(alert.Subject.ID) && a.Operator.Equals(alert.Operator) && a.SubjectProperty.Equals(alert.SubjectProperty) && a.Value.Equals(alert.Value)).First();
            }
            catch (Exception)
            {
                return sentimentAlert;
            }
            return sentimentAlert;
        }

        public TrendAlert FindTrendAlert(TrendAlert alert)
        {
            TrendAlert trendAlert = null;
            try
            {
                trendAlert = context.Alerts.OfType<TrendAlert>().Where(a => a.Subject.ID.Equals(alert.Subject.ID)).First();
            }
            catch (Exception)
            {
                return trendAlert;
            }
            return trendAlert;
        }

        public CompareAlert FindCompareAlert(CompareAlert alert)
        {
            CompareAlert compareAlert = null;
            try
            {
                compareAlert = context.Alerts.OfType<CompareAlert>().Where(a => a.SubjectA.ID.Equals(alert.SubjectA.ID) && a.SubjectB.ID.Equals(alert.SubjectB.ID) && a.Operator.Equals(alert.Operator)).First();
            }
            catch (Exception)
            {
                return compareAlert;
            }
            return compareAlert;
        }
    }
}
