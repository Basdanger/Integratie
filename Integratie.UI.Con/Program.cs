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
using System.Timers;

namespace Integratie.UI.Con
{
    public class Program
    {
        private static OrganisationManager omgr = new OrganisationManager();
        private static FeedManager mgr = new FeedManager();
        private static TextgainManager textGainManager = new TextgainManager();
        static void Main(string[] args)
        {
            //Console.WriteLine(textGainManager.dashBoardDbTextGain.postJson());
            textGainManager.SetTimer();
            Console.WriteLine(omgr.GetOrganisation(1002).Full_Name);
            Console.ReadLine();
        }
    }
}
