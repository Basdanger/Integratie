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

namespace Integratie.BL.Managers
{
    public class AlertManager
    {
        // test
        IAlertRepo ar = new DummyAlertRepo();
        public void CheckAlerts()
        {
            foreach (Alert a in ar.GetAlerts())
            {
                if  (a.GetType() == typeof(CheckAlert))
                {
                    CheckCheckAlert((CheckAlert)a);
                } else if (a.GetType() == typeof(CompareAlert))
                {
                    CheckCompareAlert((CompareAlert)a);
                } else if (a.GetType() == typeof(TrendAlert))
                {
                    CheckTrendAlert((TrendAlert)a);
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
        public bool CheckCompareAlert(CompareAlert alert)
        {
            Subject subjectA = alert.SubjectA;
            Subject subjectB = alert.SubjectB;

            int fcA = 0;
            int fcB = 0;

            foreach(Feed f in subjectA.Feeds)
            {
                if (f.Date.Ticks > DateTime.Now.AddDays(-7).Ticks && f.Date.Ticks < DateTime.Now.Ticks)
                {
                    fcA++;
                }
            }

            foreach (Feed f in subjectB.Feeds)
            {
                if (f.Date.Ticks > DateTime.Now.AddDays(-7).Ticks && f.Date.Ticks < DateTime.Now.Ticks)
                {
                    fcB++;
                }
            }

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

            foreach(Feed f in subject.Feeds)
            {
                if (f.Date.Ticks > DateTime.Now.AddDays(-1).Ticks)
                {
                    fcToday++;
                }
            }

            for (int i = 0; i < days; i++)
            {
                foreach (Feed f in subject.Feeds)
                {
                    if (f.Date.Ticks > DateTime.Now.AddDays(-2 -i).Ticks && f.Date.Ticks < DateTime.Now.AddDays(-1 -i).Ticks)
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
            } else
            return false;
        }
    }
}
