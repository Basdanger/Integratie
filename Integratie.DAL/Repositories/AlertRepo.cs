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

        public UserAlert GetUserAlert(int user, int alert)
        {
            return (UserAlert)context.UserAlerts.Where(u => u.Account.ID.Equals(user) && u.Alert.ID.Equals(alert));
        }

        public IEnumerable<UserAlert> GetUserAlerts()
        {
            return context.UserAlerts.ToList<UserAlert>();
        }

        public IEnumerable<UserAlert> GetUserAlertsOfAlert(int alertId)
        {
            return context.UserAlerts.Where(u => u.Alert.ID.Equals(alertId)).ToList<UserAlert>();
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

        public Alert CheckAlert(Alert alert)
        {
            return context.Alerts.FirstOrDefault(a => a.Equals(alert));
        }
    }
}
