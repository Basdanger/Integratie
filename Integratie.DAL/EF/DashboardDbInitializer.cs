using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Subjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    public class DashboardDbInitializer : DropCreateDatabaseAlways<DashBoardDbContext>
    {
        private DashBoardDbTextGain dashBoardDbTextgain = new DashBoardDbTextGain();
        protected override void Seed(DashBoardDbContext context)
        {
            List<Feed> feeds = new List<Feed>();
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(dashBoardDbTextgain.postJson());
            foreach (var item in rootObject.Feeds)
            {
                feeds.Add(new Feed(item.ID, item.Gender, item.Age, item.Education, item.Language, item.Personality, item.Words, item.Sentiment, item.Source, item.Hashtags, item.Themes, item.Persons, item.Urls, item.Date, item.Mentions, item.Geo, item.Retweet));
            }
            foreach (var feed in feeds)
            {
                context.Feeds.Add(feed);
            }

            context.SaveChanges();
            
            /*
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

            context.SaveChanges();    
            */
        }
    }
}
