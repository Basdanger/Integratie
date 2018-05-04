using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Dashboard;
using Integratie.Domain.Entities.Graph;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    public class DashboardDbInitializer : DropCreateDatabaseIfModelChanges<DashBoardDbContext>
    {
        protected override void Seed(DashBoardDbContext context)
        {
            //DUMMY FEEDS
            List<Feed> list = new List<Feed>()
            {
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now, 3),
                new Feed(DateTime.Now, 3),
                new Feed(DateTime.Now, 3),

                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(1), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(1), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),

                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-7), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),

                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-0), 3),
                new Feed(DateTime.Now.AddDays(-0), 3),
                new Feed(DateTime.Now.AddDays(-0), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),

                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-7), 3),
                new Feed(DateTime.Now.AddDays(1), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),

                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(0), 3),

                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(1), 3),

                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),

                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(-1), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-5), 3),

                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(-3), 3),
                new Feed(DateTime.Now.AddDays(-2), 3),
                new Feed(DateTime.Now.AddDays(1), 3),
                new Feed(DateTime.Now.AddDays(-4), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(0), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
                new Feed(DateTime.Now.AddDays(-6), 3),
            };

            foreach (var item in list)
            {
                context.Feeds.Add(item);
            }

            //DUMMY SUBJECTS
            Subject S1 = new Subject(1, "Bart De Wever");
            for (int i = 0; i < 11; i++)
            {
                S1.AddFeed(list[i]);
            }

            Subject S2 = new Subject(2, "Maggie De Block");
            for (int i = 11; i < 21; i++)
            {
                S2.AddFeed(list[i]);
            }

            Subject S3 = new Subject(3, "Kris Peeters");
            for (int i = 21; i < 31; i++)
            {
                S3.AddFeed(list[i]);
            }

            Subject S4 = new Subject(4, "Charles Michel");
            for (int i = 31; i < 40; i++)
            {
                S4.AddFeed(list[i]);
            }
            //DUMMY ALERTS
            CheckAlert CH1 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1.5, S1);
            CheckAlert CH2 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, S2);
            CheckAlert CH3 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, S3);
            CheckAlert CH4 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1, S4);
            CompareAlert CO1 = new CompareAlert(S1, S2, Operator.GT);
            CompareAlert CO2 = new CompareAlert(S1, S2, Operator.LT);
            TrendAlert TR1 = new TrendAlert(S1);

            context.Alerts.Add(CH1);
            context.Alerts.Add(CH2);
            context.Alerts.Add(CH3);
            context.Alerts.Add(CH4);
            context.Alerts.Add(CO1);
            context.Alerts.Add(CO2);
            context.Alerts.Add(TR1);

            //ACCOUNTS
            Account A1 = new Account(0, "JanVH", "jvanhoye@hotmail.com");
            

            //GRAPHS
            BarChartGraph BCG1 = new BarChartGraph(new List<Subject> { S1, S2 }, A1);
            BarChartGraph BCG2 = new BarChartGraph(new List<Subject> { S3, S4 }, A1);
            context.Graphs.Add(BCG1);
            context.Graphs.Add(BCG2);

            //DashboardItems
            DashboardItem DBI1 = new DashboardItem(0, 1, 1, 1, 1, BCG1);
            DashboardItem DBI2 = new DashboardItem(1, 1, 2, 1, 1, BCG2);
            DashboardItem DBI3 = new DashboardItem(2, 1, 3, 2, 2, BCG2);
            //DashboardItem DBI1 = new DashboardItem(1,)
            context.Dashboarditems.Add(DBI1);
            context.Dashboarditems.Add(DBI2);
            context.Dashboarditems.Add(DBI3);
            context.SaveChanges();
        }
    }
}
