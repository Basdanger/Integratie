using Integratie.Domain.Entities.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories.Interfaces
{
    public interface IAlertRepo
    {
        IEnumerable<Alert> GetAlerts();
        Alert GetAlertById(int id);
        void RemoveAlert(Alert alert);
        void AddAlert(Alert alert);
        UserAlert GetUserAlert(string user, int alert);
        void AddUserAlert(UserAlert userAlert);
        IEnumerable<UserAlert> GetUserAlerts();
        IEnumerable<UserAlert> GetUserAlertsOfUser(string userId);
        IEnumerable<UserAlert> GetUserAlertsOfAlert(int alertId);
    }
}
