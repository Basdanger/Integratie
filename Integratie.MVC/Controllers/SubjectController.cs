using CsvHelper;
using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
using Integratie.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class SubjectController : Controller
    {
        private SubjectManager mgr = new SubjectManager();
        // GET: Subject
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Personen()
        {
            IEnumerable<Person> personen = mgr.GetPersonen();
            return View(personen);
        }
        public ActionResult Persoon(String Full_Name)
        {
            PersonAndFeeds pf = new PersonAndFeeds();
            pf.person = mgr.GetPersoon(Full_Name);
            pf.feeds = mgr.GetFeeds(Full_Name);
            return View(pf);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult EditPersoon(String Full_Name)
        {
            Person person = mgr.GetPersoon(Full_Name);
            return View();
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditPersoon(String Full_Name, Person person)
        {
            try
            {
                mgr.ChangePerson(person);
                return RedirectToAction("Personen");
            }
            catch
            {
                return View();
            }
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult DeletePerson(String Full_Name)
        {
            Person p = mgr.GetPersoon(Full_Name);
            return View(p);
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeletePerson(String Full_Name, FormCollection collection)
        {
            try
            {
                mgr.DeletePerson(Full_Name);

                return RedirectToAction("Personen");
            }
            catch
            {
                return View();
            }
        }
       // [Authorize(Roles = "Admin")]
        public ActionResult CreatePersoon()
        {
            return View();
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreatePersoon(Person person, FormCollection collection)
        {
            try
            {
                person = mgr.AddPerson(
                person.First_Name,
                person.Last_Name,
                person.District,
                person.Level,
                person.Gender,
                person.Twitter,
                person.Site,
                person.DateOfBirth,
                person.Facebook,
                person.Postal_Code,
                person.Full_Name,
                person.Position,
                person.Organisation,
                person.Town
                );
                return RedirectToAction("Personen");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Organisaties()
        {
            IEnumerable<Person> organisaties = mgr.GetOrganisaties();
            return View(organisaties);
        }
        public ActionResult PersonenPerOrganisatie(String Organisatie)
        {
            IEnumerable<Person> personen = mgr.GetPeopleByOrganisation(Organisatie);
            return View(personen);
        }
        public ActionResult Gemeente()
        {
            ViewBag.Message = "Your Towns Page";
            string[] gemeentes = { "AALST",
"AARTSELAAR",
"ANDERLECHT",
"ANTWERPEN",
"BELSELE",
"BERCHEM",
"BORGERHOUT",
"BORSBEKE",
"BOUWEL",
"BRASSCHAAT",
"BRUSSEL",
"DE PANNE",
"DESSEL",
"DEURNE",
"DIEPENBEEK",
"DUFFEL",
"EDEGEM",
"EKEREN",
"GANSHOREN",
"GEEL",
"GENK",
"GENT",
"HARELBEKE",
"HEUSDEN",
"HOBOKEN",
"HOEILAART",
"JETTE",
"KACHTEM",
"KALMTHOUT",
"KAPELLEN",
"KESSEL LO",
"KOERSEL",
"KOOLKERKE",
"KORTRIJK",
"KRAAINEM",
"KRUISHOUTEM",
"LEDEBERG",
"LEEFDAAL",
"LEOPOLDSBURG",
"LEUVEN",
"LIEDEKERKE",
"LIER",
"LOKEREN",
"LOMMEL",
"LUBBEEK",
"MALDEGEM",
"MEERBEEK",
"MEERLE",
"MEISE",
"MELLE",
"MERCHTEM",
"MERKSPLAS",
"MOL",
"MORTSEL",
"NEDEROKKERZEEL",
"NEDER-OVER-HEEMBEEK",
"NIEUWERKERKEN",
"NOORDERWIJK",
"OETINGEN",
"OPWIJK",
"OUDERGEM",
"OUD-TURNHOUT",
"POEKE",
"RAMSDONK",
"RAMSEL",
"REKKEM",
"ROLLEGEM",
"ROTSELAAR",
"RUISBROEK",
"RUMBEKE",
"SCHAARBEEK",
"SCHELDERODE",
"SCHILDE",
"SCHULEN",
"SINT-AGATHA-RODE",
"SINT-AMANDSBERG",
"SINT-GILLIS-DENDERMONDE",
"SINT-JAN",
"SINT-JANS-MOLENBEEK",
"SINT-JOOST-TEN-NOODE",
"SINT-LAMBRECHTS-HERK",
"SINT-MARTENS-LATEM",
"SINT-MARTENS-LENNIK",
"SINT-NIKLAAS",
"SINT-PAUWELS",
"SINT-PIETERS-WOLUWE",
"SINT-ULRIKS-KAPELLE",
"SLEIDINGE",
"STEENHUFFEL",
"STOKKEM",
"STOKROOIE",
"TIELEN",
"TORHOUT",
"UITBERGEN",
"UKKEL",
"VELDWEZELT",
"VELM",
"VILVOORDE",
"VISSENAKEN",
"VLISSEGEM",
"VOORDE",
"VOSSEM",
"VRASENE",
"WALEM",
"WALTWILDER",
"WELDEN",
"WESPELAAR",
"WESTKAPELLE",
"WIDOOIE",
"WIEKEVORST",
"WIEZE",
"WIJSHAGEN",
"WOMMELGEM",
"WULPEN",
"ZANDVOORDE",
"ZARLARDINGE",
"ZAVENTEM",
"ZEGELSEM",
"ZELE",
"ZEPPEREN",
"ZERKEGEM",
"ZEVEREN",
"ZICHEN-ZUSSEN-BOLDER",
"ZOERLE-PARWIJS",
"ZOERSEL",
"ZOLDER",
"ZONHOVEN",
"ZOTTEGEM" };
            return View(gemeentes);
        }
        public ActionResult GemeentePage(string gemeente)
        {
            SubjectManager subjectmngr = new SubjectManager();
            IEnumerable<Subject> people = subjectmngr.GetPeopleByTown(gemeente);
            return View(people);
        }
        //[HttpPost]
        //public void UploadPerson(HttpPostedFileBase file)
        //{
        //    using (var reader = new StreamReader(file.InputStream))
        //    {
        //        List<Person> personen = new List<Person>();
        //        List<String> First_Name = new List<string>();
        //        List<String> Last_Name = new List<string>();
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(',');

        //            First_Name.Add(values[0]);
        //            Last_Name.Add(values[1]);
        //        }
        //        for (int i = 0; i < First_Name.Count; i++)
        //        {
        //            personen.Add(new Person(First_Name[i], Last_Name[i]));
        //        }
        //        mgr.CreatePersons(personen);
        //    }
        //}
        [HttpPost]
        public ActionResult UploadPerson(HttpPostedFileBase file)
        {
            string path = null;
            List<Person> personen = new List<Person>();
            try
            {
                if(file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    path = AppDomain.CurrentDomain.BaseDirectory + "upload\\" + fileName;
                    file.SaveAs(path);

                    var csv = new CsvReader(new StreamReader(path));
                    var PersonList = csv.GetRecords<Person>();

                    foreach (var item in PersonList)
                    {
                        Person person = new Person();

                        person.First_Name = item.First_Name;
                        person.Last_Name = item.Last_Name;

                        personen.Add(person);
                    }
                }
            }
            catch { }
            return View(personen);
        }
    }
}