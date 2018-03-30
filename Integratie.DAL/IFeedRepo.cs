using Integratie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL
{
    public interface IFeedRepo
    {
        IEnumerable<Feed> ReadFeeds();
        void CreateFeed(Feed feed);
    }
}
