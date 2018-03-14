using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Subject
    {
        public Subject(int iD, string name)
        {
            ID = iD;
            Name = name;
            Feeds = new List<Feed>();
        }
        public void AddFeed(Feed feed)
        {
            Feeds.Add(feed);
        }

        public int ID { get; set; }
        public String Name { get; set; }
        public List<Feed> Feeds { get; set; }
    }
}
