using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain;
using Integratie.DAL.Repositories.Interfaces;

namespace Integratie.DAL.Repositories
{
    public class DummyAlertRepo : IAlertRepo
    {
        List<Alert> alerts = new List<Alert>();
        public DummyAlertRepo()
        {
            
        }
        public void AddAlert(Alert alert)
        {
            alerts.Add(alert);
        }

        public void AddUserAlert(UserAlert userAlert)
        {
            throw new NotImplementedException();
        }

        public Alert GetAlertById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Alert> GetAlerts()
        {
            return alerts;
        }

        public UserAlert GetUserAlert(int user, int alert)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alert> GetUserAlerts(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAlert> GetUserAlerts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAlert> GetUserAlertsOfAlert(int alertId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAlert> GetUserAlertsOfUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAlert(Alert alert)
        {
            alerts.Remove(alert);
        }

        IEnumerable<Alert> IAlertRepo.GetAlerts()
        {
            throw new NotImplementedException();
        }
    }
}
