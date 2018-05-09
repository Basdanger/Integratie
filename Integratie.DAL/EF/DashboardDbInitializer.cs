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
    public class DashboardDbInitializer : DropCreateDatabaseAlways<DashBoardDbContext>
    {
        public DashBoardDbTextGain dashBoardDbTextGain = new DashBoardDbTextGain();
        protected override void Seed(DashBoardDbContext context)
        {
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
            String st = File.ReadAllText(@"..\..\..\Integratie.DAL\politici.json");
            IEnumerable<Person> resultsPerson = JsonConvert.DeserializeObject<IEnumerable<Person>>(st);
            Console.WriteLine("Making " + resultsPerson.Count() + " people");
            foreach (var item in resultsPerson)
            {
                people.Add(new Person(item.First_Name, item.Last_Name, item.District, item.District, item.Gender, item.Twitter, item.Site, item.DateOfBirth, item.Facebook, item.Postal_Code, item.Full_Name, item.Position, item.Organisation, item.ID, item.Town));
            }
            Console.WriteLine("Adding " + resultsPerson.Count() + " people to database");
            foreach (var person in people)
            {
                context.People.Add(person);
            }

            Organisation OR1 = new Organisation(1001, "Nieuw-Vlaamse Alliantie", "N-VA", "www.n-va.be", 41000, context.People.SingleOrDefault(s => s.Organisation == "N-VA" && s.Position == "Voorzitter"), "Rechts", "Vlaams-nationalisme, Liberaal Conservatisme, Republicanisme", new DateTime(2001,10,13));
            Organisation OR2 = new Organisation(1002, "Christen-Democratisch en Vlaams", "CD&V", "www.cdenv.be", 57000, context.People.SingleOrDefault(s => s.Organisation == "CD&V" && s.Position == "Voorzitter"), "Centrum", "Christendemocratie", new DateTime(1945, 08, 01));
            Organisation OR3 = new Organisation(1003, "Socialistische Partij Anders", "sp.a", "www.s-p-a.be", 50000, context.People.SingleOrDefault(s => s.Organisation == "sp.a" && s.Position == "Voorzitter"), "Centrumlinks", "Sociaaldemocratie", new DateTime(1978, 01, 01));
            Organisation OR4 = new Organisation(1004, "Open Vlaamse Liberalen en Democraten", "Open Vld", "www.openvld.be", 64000, context.People.SingleOrDefault(s => s.Organisation == "Open VLD" && s.Position == "Voorzitter"), "Centrumrechts", "Liberalisme", new DateTime(1992, 01, 01));
            Organisation OR5 = new Organisation(1005, "Groen", "", "www.groen.be", 10000, context.People.SingleOrDefault(s => s.Organisation == "Groen" && s.Position == "Voorzitter"), "Links", "Ecologisme, Pacifisme, Progressivisme", new DateTime(1982, 01, 01));
            Organisation OR6 = new Organisation(1006, "Vlaams Belang", "VB", "www.vlaamsbelang.org", 17000, context.People.SingleOrDefault(s => s.Organisation == "Vlaams Belang" && s.Position == "Voorzitter"), "Extreemrechts", "Vlaams-nationalisme, Conservatisme, Euroscepsis, Republicanisme, Anti-islam", new DateTime(2004, 11, 14));
            Organisation OR7 = new Organisation(1007, "Union des Francophones", "UF", "www.uniondesfrancophones.be", 0, context.People.SingleOrDefault(s => s.Organisation == "UF" && s.Position == "Voorzitter"), "Rechts", "Franstalig expansionisme, Federaal unionisme", new DateTime(1998, 10, 01));
            Organisation OR8 = new Organisation(1008, "Partij van de Arbeid van België", "PVDA", "www.pvda.be", 10000, context.People.SingleOrDefault(s => s.Organisation == "PVDA" && s.Position == "Voorzitter"), "Links", "Marxisme", new DateTime(1979, 01, 01));

            context.Organisations.Add(OR1);
            context.Organisations.Add(OR2);
            context.Organisations.Add(OR3);
            context.Organisations.Add(OR4);
            context.Organisations.Add(OR5);
            context.Organisations.Add(OR6);
            context.Organisations.Add(OR7);
            context.Organisations.Add(OR8);

            //DUMMY ALERTS 
            CheckAlert CH1 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1.5, people[1]);
            CheckAlert CH2 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, people[2]);
            CheckAlert CH3 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 2, people[3]);
            CheckAlert CH4 = new CheckAlert(null, SubjectProperty.relativeCount, Operator.GT, 1, people[4]);
            CompareAlert CO1 = new CompareAlert(people[1], people[2], Operator.GT);
            CompareAlert CO2 = new CompareAlert(people[1], people[2], Operator.LT);
            TrendAlert TR1 = new TrendAlert(people[1]);

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
            BarChartGraph BCG1 = new BarChartGraph(new List<Subject> { people[1], people[2] }, A1);
            BarChartGraph BCG2 = new BarChartGraph(new List<Subject> { people[3], people[4] }, A1);
            context.Graphs.Add(BCG1);
            context.Graphs.Add(BCG2);

            //DashboardItems 
            DashboardItem DBI1 = new DashboardItem(0, 1, 2, 3, 3, BCG1);
            //DashboardItem DBI1 = new DashboardItem(1,) 
            context.SaveChanges();
            Console.WriteLine("Alle changes zijn opgeslagen");
        }
    }
}
