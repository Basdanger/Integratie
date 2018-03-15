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
            Feed F1 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F2 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F3 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F4 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F5 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F6 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F7 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F8 = new Feed(DateTime.Now, 3);
            Feed F9 = new Feed(DateTime.Now, 3);
            Feed F10 = new Feed(DateTime.Now, 3);

            Feed F11 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F12 = new Feed(DateTime.Now.AddDays(1), 3);
            Feed F13 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F14 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F15 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F16 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F17 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F18 = new Feed(DateTime.Now.AddDays(1), 3);
            Feed F19 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F20 = new Feed(DateTime.Now.AddDays(-4), 3);

            Feed F21 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F22 = new Feed(DateTime.Now.AddDays(-7), 3);
            Feed F23 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F24 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F25 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F26 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F27 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F28 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F29 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F30 = new Feed(DateTime.Now.AddDays(-5), 3);

            Feed F31 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F32 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F33 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F34 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F35 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F36 = new Feed(DateTime.Now.AddDays(-0), 3);
            Feed F37 = new Feed(DateTime.Now.AddDays(-0), 3);
            Feed F38 = new Feed(DateTime.Now.AddDays(-0), 3);
            Feed F39 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F40 = new Feed(DateTime.Now.AddDays(-1), 3);

            Feed F41 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F42 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F43 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F44 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F45 = new Feed(DateTime.Now.AddDays(-7), 3);
            Feed F46 = new Feed(DateTime.Now.AddDays(1), 3);
            Feed F47 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F48 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F49 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F50 = new Feed(DateTime.Now.AddDays(-5), 3);

            Feed F51 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F52 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F53 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F54 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F55 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F56 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F57 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F58 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F59 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F60 = new Feed(DateTime.Now.AddDays(0), 3);

            Feed F61 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F62 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F63 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F64 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F65 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F66 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F67 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F68 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F69 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F70 = new Feed(DateTime.Now.AddDays(1), 3);

            Feed F71 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F72 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F73 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F74 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F75 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F76 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F77 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F78 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F79 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F80 = new Feed(DateTime.Now.AddDays(-6), 3);

            Feed F81 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F82 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F83 = new Feed(DateTime.Now.AddDays(-1), 3);
            Feed F84 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F85 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F86 = new Feed(DateTime.Now.AddDays(-5), 3);
            Feed F87 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F88 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F89 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F90 = new Feed(DateTime.Now.AddDays(-5), 3);

            Feed F91 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F92 = new Feed(DateTime.Now.AddDays(-3), 3);
            Feed F93 = new Feed(DateTime.Now.AddDays(-2), 3);
            Feed F94 = new Feed(DateTime.Now.AddDays(1), 3);
            Feed F95 = new Feed(DateTime.Now.AddDays(-4), 3);
            Feed F96 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F97 = new Feed(DateTime.Now.AddDays(0), 3);
            Feed F98 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F99 = new Feed(DateTime.Now.AddDays(-6), 3);
            Feed F100 = new Feed(DateTime.Now.AddDays(-6), 3);


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
            S1.AddFeed(F11);

            Subject S2 = new Subject(2, "Maggie De Block");
            S2.AddFeed(F11);
            S2.AddFeed(F12);
            S2.AddFeed(F13);
            S2.AddFeed(F14);
            S2.AddFeed(F15);
            S2.AddFeed(F16);
            S2.AddFeed(F17);
            S2.AddFeed(F18);
            S2.AddFeed(F19);
            S2.AddFeed(F20);

            Subject S3 = new Subject(3, "Kris Peeters");
            S3.AddFeed(F21);
            S3.AddFeed(F22);
            S3.AddFeed(F23);
            S3.AddFeed(F24);
            S3.AddFeed(F25);
            S3.AddFeed(F26);
            S3.AddFeed(F27);
            S3.AddFeed(F28);
            S3.AddFeed(F29);
            S3.AddFeed(F30);

            Subject S4 = new Subject(4, "Charles Michel");
            S4.AddFeed(F31);
            S4.AddFeed(F32);
            S4.AddFeed(F33);
            S4.AddFeed(F34);
            S4.AddFeed(F35);
            S4.AddFeed(F36);
            S4.AddFeed(F37);
            S4.AddFeed(F38);
            S4.AddFeed(F39);
            S4.AddFeed(F40);

            //DUMMY ALERTS
            CheckAlert CH1 = new CheckAlert(null,SubjectProperty.relativeCount,Operator.GT,1.5,S1);
            CheckAlert CH2 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, S2);
            CheckAlert CH3 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, S3);
            CheckAlert CH4 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1, S4);
            CompareAlert CO1 = new CompareAlert(S1, S2, Operator.GT);
            CompareAlert CO2 = new CompareAlert(S1, S2, Operator.LT);

            alerts.Add(CH1);
            alerts.Add(CH2);
            alerts.Add(CH3);
            alerts.Add(CH4);
            alerts.Add(CO1);
            alerts.Add(CO2);
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
