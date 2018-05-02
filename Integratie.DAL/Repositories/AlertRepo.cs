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

        public Alert GetAlertById(int id)
        {
            return context.Alerts.Find(id);
        }

        public IEnumerable<Alert> GetAlerts()
        {
            return context.Alerts.ToList<Alert>();
        }

        public IEnumerable<Alert> GetUserAlerts(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAlert(Alert alert)
        {
            context.Alerts.Remove(alert);
        }
    }
}
