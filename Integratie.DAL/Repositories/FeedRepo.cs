using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.DAL.Repositories.Interfaces;

namespace Integratie.DAL.Repositories
{
    public class FeedRepo : IFeedRepo
    {
        private DashBoardDbContext context;

        public FeedRepo()
        {
            context = new DashBoardDbContext(); 
        }

        public IEnumerable<Feed> ReadFeeds()
        {
            IEnumerable<Feed> feeds = context.Feeds.ToList<Feed>();
            return feeds;
        }

        public void CreateFeed(Feed feed)
        {
            context.Feeds.Add(feed);
            context.SaveChanges();
        }
    }
}
