using Integratie.BL;
using Integratie.DAL;
using Integratie.Domain.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.UI.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Proof of Concept";
            IAlertRepo ar = new DummyAlertRepo();
            AlertManager am = new AlertManager();
            Console.WriteLine("Proof Of Concept");
            Console.WriteLine("Team Tesla");
            Console.WriteLine("-----------------");
            foreach (Alert a in ar.GetAlerts())
            {
                Console.WriteLine("Alert Type: " + a.GetType().Name);
                if (a.GetType() == typeof(CheckAlert))
                {
                    CheckAlert ca = (CheckAlert)a;
                    Console.WriteLine("Alert ID: " + a.ID);
                    Console.WriteLine("Alert Subject: " + ca.Subject.Name);
                    Console.WriteLine("Alert Expression: "+ ca.SubjectProperty.ToString() + " " + ca.Operator.ToString() + " " + ca.Value.ToString());
                    bool result = am.CheckCheckAlert((CheckAlert)a);
                    Console.Write("Alert Ring: ");
                    if (result == true) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
                if (a.GetType() == typeof(CompareAlert))
                {
                    CompareAlert ca = (CompareAlert)a;
                    Console.WriteLine("Alert ID: " + ca.ID);
                    Console.WriteLine("Alert SubjectA: " + ca.SubjectA.Name + " Operator: " + ca.Operator + " Alert SubjectB: " + ca.SubjectB.Name);
                    bool result = am.CheckCompareAlert(ca);
                    Console.Write("Alert Ring: ");
                    if (result == true) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
                if (a.GetType() == typeof(TrendAlert))
                {
                    TrendAlert ca = (TrendAlert)a;
                    Console.WriteLine("Alert ID: " + ca.ID);
                    Console.WriteLine("Alert SubjectA: " + ca.Subject.Name);
                    bool result = am.CheckTrendAlert(ca);
                    Console.Write("Alert Ring: ");
                    if (result == true) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
