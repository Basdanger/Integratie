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
        private static AlertManager mgr = new AlertManager();

        static void Main(string[] args)
        {
            //Console.WriteLine(mgr.GetFeed(982262187350573060).Profile.Age + mgr.GetFeed(982262187350573060).Geo);
            //mgr.AddUserAlert("0", "Trend", "Bart De Wever", true, true, true, "", "", "",0);
            //Console.WriteLine("Alert added");
            //mgr.AddUserAlert("1", "Trend", "Bart De Wever", true, true, true, "", "", "", 0);
            //Console.WriteLine("Alert added");
            IEnumerable<UserAlert> alerts = mgr.GetUserAlertsOfUser("0");
            UserAlert userAlert = alerts.First();
            userAlert.Mail = false;
            mgr.UpdateUserAlert(userAlert);
            Console.WriteLine("Updated");
            Console.ReadLine();
        }

        //private static void PrintAllFeeds()
        //{
        //    foreach (var t in mgr.GetFeeds())
        //        Console.WriteLine(t.ID);
        //}
    }
}
