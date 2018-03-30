using Integratie.BL.Managers.Interfaces;
using Integratie.DAL;
using Integratie.Domain;
using Integratie.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class RecordManager : IRecordManager
    {
        private IFeedRepo repo;

        public RecordManager()
        {
            repo = new FeedRepo();
        }

        //Leest de file en insert de feeds in de database
        public void ReadFile()
        {
            List<Feed> feeds = new List<Feed>();
            String st = File.ReadAllText("C:\\Users\\GLaDOS\\Desktop\\textgaindump.json");
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(st);
            foreach (var item in rootObject.records)
            {
                feeds.Add(new Feed(item.date));
            }
            foreach (var feed in feeds)
            {
                repo.CreateFeed(feed);
            }
        }
    }
}
