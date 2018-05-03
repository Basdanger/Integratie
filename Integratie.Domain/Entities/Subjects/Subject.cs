using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Subject
    {
        public Subject(int iD, string name)
        {
            ID = iD;
            Name = name;
            Feeds = new List<Feed>();
            FeedCount = Feeds.Count();
    }

        public Subject()
        {
        }

        public void AddFeed(Feed feed)
        {
            Feeds.Add(feed);
            FeedCount = Feeds.Count();
        }

        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public List<Feed> Feeds { get; set; }
        public int FeedCount { get; set; }
    }
}
