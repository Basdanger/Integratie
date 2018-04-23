using Integratie.BL;
using Integratie.DAL;
using Integratie.Domain.Entities.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.BL.Managers;
using Integratie.Domain.Entities;

namespace Integratie.UI.Con
{
    class Program
    {
        private static DashBoardDbTextGain api = new DashBoardDbTextGain();
        private static FeedManager mgr = new FeedManager();
        static void Main(string[] args)
        {
            Console.WriteLine(api.postJson());
            Console.WriteLine(PrintAllFeeds(mgr.GetFeed(987053307431673856)));
            //rcdmgr.ReadFile();
            Console.ReadLine();
        }

        private static String PrintAllFeeds(Feed feed)
        {
            return String.Format("{0} {1}", feed.ID, feed.Geo);
        }
    }
}
