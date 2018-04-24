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
using System.IO;

namespace Integratie.UI.Con
{
    class Program
    {
        private static FeedManager mgr = new FeedManager();
        private static RecordManager rcdmgr = new RecordManager();
        private static MailManager mailManager = new MailManager();

        static void Main(string[] args)
        {
            //PrintAllFeeds();
            //rcdmgr.ReadFile();
            SendMail();

            Console.ReadLine();
        }

        private static void PrintAllFeeds()
        {
            foreach (var t in mgr.GetFeeds())
                Console.WriteLine(t.ID);
        }

        private static void SendMail()
        {
            Console.WriteLine("Type mail to send: ");
            string body = Console.ReadLine();
            mailManager.SendMail(body);
        }
    }
}
