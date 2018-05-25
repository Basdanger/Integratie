using Integratie.DAL.ResourcesInit;
using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Dashboard;
using Integratie.Domain.Entities.Graph;
using Integratie.Domain.Entities.Subjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    public class DashboardDbInitializer : CreateDatabaseIfNotExists<DashBoardDbContext>
    {
        protected override void Seed(DashBoardDbContext context)
        {
            DashBoardDbTextGain dashBoardDbTextGain = new DashBoardDbTextGain();
            List<Feed> feeds = new List<Feed>();
            IEnumerable<Feed> resultsFeed = JsonConvert.DeserializeObject<IEnumerable<Feed>>(dashBoardDbTextGain.postJson());

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
            String st = SubjectStrings.Politicians();
            //String st = File.ReadAllText(@"C:\Users\yanni\net\Integratie.DALpolitici.json");
            ////String st = File.ReadAllText(@"D:\nikol\Documents\IntegratieprojectClone\net\Integratie.DAL\politici.json");
            //String st = File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "politici.json"));

            IEnumerable<Person> resultsPerson = new List<Person>();
            resultsPerson = JsonConvert.DeserializeObject<IEnumerable<Person>>(st);
            Console.WriteLine("Making" + resultsFeed.Count() + "people");
            foreach (var item in resultsPerson)
            {
                people.Add(new Person(item.First_Name, item.Last_Name, item.District, item.District, item.Gender, item.Twitter, item.Site, item.DateOfBirth, item.Facebook, item.Postal_Code, item.Full_Name, item.Position, item.Organisation, item.Town));
            }
            Console.WriteLine("Adding" + resultsPerson.Count() + "people to database");
            foreach (var person in people)
            {
                context.People.Add(person);
            }
            //List<Organisation> org = new List<Organisation>();
            //IEnumerable<Organisation> organisations = new List<Organisation>();
            //organisations = JsonConvert.DeserializeObject<IEnumerable<Organisation>>(st);
            //foreach (var item in organisations)
            //{
            //    org.Add(new Organisation(item.ID, item.Naam));
            //}
            //foreach (var o in org)
            //{
            //    context.Organisations.Add(o);
            //}
            //DUMMY ALERTS
            //CheckAlert CH1 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1.5, people[1]);
            //CheckAlert CH2 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, people[2]);
            //CheckAlert CH3 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, people[3]);
            //CheckAlert CH4 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1, people[4]);
            //CompareAlert CO1 = new CompareAlert(people[1], people[2], Operator.GT);
            //CompareAlert CO2 = new CompareAlert(people[1], people[2], Operator.LT);
            //TrendAlert TR1 = new TrendAlert(people[1]);

            //context.Alerts.Add(CH1);
            //context.Alerts.Add(CH2);
            //context.Alerts.Add(CH3);
            //context.Alerts.Add(CH4);
            //context.Alerts.Add(CO1);
            //context.Alerts.Add(CO2);
            //context.Alerts.Add(TR1);

            WeeklyAlert weeklyAlert = new WeeklyAlert();
            context.Alerts.Add(weeklyAlert);

            //ACCOUNTS
            //Account A1 = new Account("0", "JanVH", "jvanhoye@hotmail.com");
            //Account A2 = new Account("1", "Jorno", "DenJorno@hotmail.com");
            //context.Accounts.Add(A1);
            //context.Accounts.Add(A2);

            //USERALERTS
            //UserAlert UA1 = new UserAlert(A1, CH1, true, false, false);
            //context.UserAlerts.Add(UA1);

            context.SaveChanges();
        }
    }
}
