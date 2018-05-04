using Integratie.Domain;
using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers.Interfaces
{
    public interface IFeedManager
    {
        IEnumerable<Feed> GetFeeds();
        Feed GetFeed(double id);
    }
}
