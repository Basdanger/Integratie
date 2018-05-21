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
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.UI.Con
{
    class Program
    {
        private static AccountManager mgr = new AccountManager();
        private static SubjectManager subjectManager = new SubjectManager();

        static void Main(string[] args)
        {
            //Console.WriteLine(mgr.GetFeed(982262187350573060).Profile.Age + mgr.GetFeed(982262187350573060).Geo);
            Subject subject = subjectManager.GetSubjectById(1);
            mgr.UpdateFollow("0", 1);
            Console.WriteLine(mgr.GetAccountById("0").Follows.Contains(subject));
            mgr.UpdateFollow("0", 1);
            Console.WriteLine(mgr.GetAccountById("0").Follows.Contains(subject));
            Console.ReadLine();
        }

        //private static void PrintAllFeeds()
        //{
        //    foreach (var t in mgr.GetFeeds())
        //        Console.WriteLine(t.ID);
        //}
    }
}
