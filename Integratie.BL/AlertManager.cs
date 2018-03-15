using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Alerts;
using Integratie.DAL;
using Integratie.Domain;

namespace Integratie.BL
{
    public class AlertManager
    {
        IAlertRepo ar = new DummyAlertRepo();
        public void CheckAlerts()
        {
            foreach (Alert a in ar.GetAlerts())
            {
                if  (a.GetType() == typeof(CheckAlert))
                {
                    CheckCheckAlert((CheckAlert)a);
                }
            }
        }
        public bool CheckCheckAlert(CheckAlert alert)
        {
            Subject subject = alert.Subject;
            int fc = 0;
            foreach(Feed f in subject.Feeds)
            {
                if(f.Date.Ticks > DateTime.Now.AddDays(-7).Ticks && f.Date.Ticks < DateTime.Now.AddDays(-1).Ticks)
                {
                    fc++;
                }
            }


            fc = fc / 6;

            int fc2 = 0;
            foreach (Feed f in subject.Feeds)
            {
                if (f.Date.Ticks > DateTime.Now.AddDays(-1).Ticks)
                {
                    fc2++;
                }
            }

            int result = fc2 / fc;
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
        public void CheckCompareAlert(CompareAlert alert)
        {

        }
    }
}
