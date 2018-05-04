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
