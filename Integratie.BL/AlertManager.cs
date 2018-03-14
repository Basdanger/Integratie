using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Alerts;
using Integratie.DAL;

namespace Integratie.BL
{
    public class AlertManager
    {
        DummyAlertRepo dar = new DummyAlertRepo();
        public void CheckAlerts()
        {
            foreach (Alert a in dar.GetAlerts())
            {
                if  (a.GetType() == typeof(CheckAlert))
                {
                    CheckAlert((CheckAlert)a);
                }
            }
        }
        public void CheckAlert(CheckAlert alert)
        {
            
        }
    }
}
