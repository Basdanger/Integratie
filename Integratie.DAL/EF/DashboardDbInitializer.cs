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
    public class DashboardDbInitializer : DropCreateDatabaseIfModelChanges<DashBoardDbContext>
    {
        private DashBoardDbTextGain dashBoardDbTextgain = new DashBoardDbTextGain();
        protected override void Seed(DashBoardDbContext context)
        {
            List<Feed> feeds = new List<Feed>();
            IEnumerable<Feed> results = JsonConvert.DeserializeObject<IEnumerable<Feed>>(dashBoardDbTextgain.postJson());
            foreach (var item in results)
            {
                if (item.Geo.GetType().Equals(typeof(bool)))
                {
                    item.Geo = new List<double>() { 0, 0 };
                }
                feeds.Add(new Feed(item.ID, new Profile(item.Profile.Gender, item.Profile.Age, item.Profile.Education, item.Profile.Language, item.Profile.Personality), item.Words, item.Sentiment, item.Source, item.Hashtags, item.Themes, item.Persons, item.Urls, item.Date, item.Mentions, item.Geo, item.Retweet));
            }
            foreach (var feed in feeds)
            {
                context.Feeds.Add(feed);
                context.SaveChanges();
            }
            }
    }
}
