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
using Integratie.Domain.Entities.Subjects;
using Newtonsoft.Json;

namespace Integratie.UI.Con
{
    class Program
    {
        private static AlertManager mgr = new AlertManager();

        static void Main(string[] args)
        {
            SubjectManager subject = new SubjectManager();
            //Console.WriteLine(mgr.GetFeed(982262187350573060).Profile.Age + mgr.GetFeed(982262187350573060).Geo);
            //mgr.AddUserAlert("0", "Trend", "Bart De Wever", true, true, true, "", "", "",0);
            //Console.WriteLine("Alert added");
            //mgr.AddUserAlert("1", "Trend", "Bart De Wever", true, true, true, "", "", "", 0);
            //Console.WriteLine("Alert added");
            Dictionary<string, int> valuePairs = new Dictionary<string, int>();
            List<int> values = new List<int>();
            int value;

            Random random = new Random(5);
            value = random.Next(50);
            valuePairs.Add("one", value);
            value = random.Next(50);
            valuePairs.Add("two", value);

            string json = JsonConvert.SerializeObject(valuePairs);
            Console.WriteLine(json);
            valuePairs.Clear();
            valuePairs = JsonConvert.DeserializeObject<Dictionary<string,int>>(json);
            foreach (string item in valuePairs.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(valuePairs[item]);
            }
            Console.ReadLine();
        }

        //private static void PrintAllFeeds()
        //{
        //    foreach (var t in mgr.GetFeeds())
        //        Console.WriteLine(t.ID);
        //}
    }
}
