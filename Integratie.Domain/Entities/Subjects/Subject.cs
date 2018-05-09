using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public abstract class Subject
    {
        [Key]
        public double ID { get; set; }
        public String Full_Name { get; set; }
        public List<Feed> Feeds { get; set; }
        public int FeedCount { get; set; }

        public Subject()
        {

        }
        public Subject(double id, string full_name)
        {
            ID = id;
            Full_Name = full_name;
            Feeds = new List<Feed>();
            FeedCount = Feeds.Count();
    }
        public void AddFeed(Feed feed)
        {
            Feeds.Add(feed);
            FeedCount = Feeds.Count();
        }
    }
}
