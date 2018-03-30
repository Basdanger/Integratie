using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL;
using Integratie.Domain;

namespace Integratie.BL
{
    public class FeedManager : IFeedManager
    {
        private IFeedRepo repo;

        public FeedManager()
        {
            repo = new FeedRepo();
        }
        public IEnumerable<Feed> GetFeeds()
        {
            return repo.ReadFeeds();
        }
    }
}
