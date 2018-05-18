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
            //Person person;
            //subject.GetPersonen();
            //person = subject.GetPersoon("Bart De Wever");
            //person.Full_Name = "Filip De Wever";
            //subject.ChangePerson(person);
            
            Console.ReadLine();
        }

        //private static void PrintAllFeeds()
        //{
        //    foreach (var t in mgr.GetFeeds())
        //        Console.WriteLine(t.ID);
        //}
    }
}
