using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Graph;
using Integratie.Domain.Entities.Subjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            IEnumerable<Feed> resultsFeed = JsonConvert.DeserializeObject<IEnumerable<Feed>>(dashBoardDbTextgain.postJson());

            Console.WriteLine("Making " + resultsFeed.Count() + " feeds");
            foreach (var item in resultsFeed)
            {
                feeds.Add(new Feed(new Profile(item.Profile.Gender, item.Profile.Age, item.Profile.Education, item.Profile.Language, item.Profile.Personality), item.Words, item.Sentiment, item.Source, item.Hashtags, item.ID, item.Themes, item.Persons, item.Urls, item.Date, item.Mentions, item.Geo, item.Retweet));
            }

            Console.WriteLine("Adding " + resultsFeed.Count() + " feeds to database");
            foreach (var feed in feeds)
            {
                context.Feeds.Add(feed);
                
            }

            List<Person> people = new List<Person>();
            String st = File.ReadAllText(@"F:\School\Repositories\Integratieproject 1\net\Integratie.DAL\politici.json");
            IEnumerable <Person> resultsPerson = JsonConvert.DeserializeObject<IEnumerable<Person>>(st);
            Console.WriteLine("Making" + resultsFeed.Count() + "people");
            foreach (var item in resultsPerson)
            {
                people.Add(new Person(item.First_Name, item.Last_Name, item.District, item.District, item.Gender, item.Twitter, item.Site, item.DateOfBirth, item.Facebook, item.Postal_Code, item.Full_Name, item.Position, item.Organisation, item.Id, item.Town));
            }
            Console.WriteLine("Adding" + resultsPerson.Count() + "people to database");
            foreach (var person in people)
            {
                context.People.Add(person);
            }

            context.SaveChanges();
        }
    }
}
