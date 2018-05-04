using Integratie.BL.Managers.Interfaces;
using Integratie.DAL.EF;
using Integratie.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Integratie.BL.Managers
{
    public class TextgainManager : ITextgainManager
    {
        public Timer timer { get; set; }
        public DashBoardDbTextGain dashBoardDbTextGain = new DashBoardDbTextGain();
        public FeedManager feedManager = new FeedManager();
        private int Counter = 0;

        public void SetTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(UpdateDatabase);
            timer.Interval = 600000;
            timer.Start();
        }

        public void UpdateDatabase(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Updating Database");
            List<Feed> feeds = new List<Feed>();
            IEnumerable<Feed> resultsFeed = JsonConvert.DeserializeObject<IEnumerable<Feed>>(dashBoardDbTextGain.postJson());
            foreach (var item in resultsFeed)
            {
                feeds.Add(new Feed(new Profile(item.Profile.Gender, item.Profile.Age, item.Profile.Education, item.Profile.Language, item.Profile.Personality), item.Words, item.Sentiment, item.Source, item.Hashtags, item.ID, item.Themes, item.Persons, item.Urls, item.Date, item.Mentions, item.Geo, item.Retweet));
            }
            foreach (var feed in feeds)
            {
                if (!feedManager.CheckFeed(feed))
                {
                    feedManager.MakeFeed(feed);
                    Counter++;
                }
            }
            Console.WriteLine("Database Updated: {0} new feeds", Counter);
        }
    }
}
