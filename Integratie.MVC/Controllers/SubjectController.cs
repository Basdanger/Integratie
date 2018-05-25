using CsvHelper;
using ExcelDataReader;
using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Subjects;
using Integratie.MVC.Models;
using LINQtoCSV;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
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
        private FeedManager feedManager = new FeedManager();
        private AccountManager accountManager = new AccountManager();
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
        public ActionResult Persoon(int id, String Full_Name)
        {
            PersonAndFeeds pf = new PersonAndFeeds();
            pf.person = mgr.GetPersoon(id);
            pf.feeds = feedManager.GetPersonFeeds(Full_Name);
            if (Request.IsAuthenticated)
            {
                ViewBag.Follow = accountManager.GetAccountById(User.Identity.GetUserId()).Follows.Exists(f => f.ID.Equals(pf.person.ID));
            }
            return View(pf);
        }

        //public ActionResult Persoon(String Full_Name)
        //{
        //    PersonAndFeeds pf = new PersonAndFeeds();
        //    pf.person = (Person) mgr.GetSubjectByName(Full_Name);
        //    pf.feeds = feedManager.GetPersonFeeds(Full_Name);
        //    if (Request.IsAuthenticated)
        //    {
        //        ViewBag.Follow = accountManager.GetAccountById(User.Identity.GetUserId()).Follows.Exists(f => f.ID.Equals(pf.person.ID));
        //    }
        //    return View(pf);
        //}

        public ActionResult PersoonAlert(Subject subject,Alert alert)
        {
            ViewBag.Alert = alert;
            return Persoon(subject.ID, subject.Name);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditPersoon(int id)
        {
            Person person = mgr.GetPersoon(id);
            return View(person);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePerson(int id)
        {
            Person p = mgr.GetPersoon(id);
            return View(p);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeletePerson(int id, FormCollection collection)
        {
            try
            {
                mgr.DeletePerson(id);

                return RedirectToAction("Personen");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePersoon()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
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
            IEnumerable<String> organisaties = mgr.GetOrganisaties();
            return View(organisaties.ToArray());
        }
        public ActionResult PersonenPerOrganisatie(String Organisatie)
        {
            IEnumerable<Person> personen = mgr.GetPeopleByOrganisation(Organisatie);
            ViewBag.Description = Organisatie;
            return View(personen);
        }
        public ActionResult Gemeente()
        {
            ViewBag.Message = "Gemeentes";
            IEnumerable<String> gemeentes = mgr.GetGemeentes();
            return View(gemeentes.ToArray());
        }
        public ActionResult GemeentePage(string gemeente)
        {
            IEnumerable<Subject> people = mgr.GetPeopleByTown(gemeente);
            return View(people);
        }
        [HttpPost]
        public ActionResult CSVOpladen(HttpPostedFileBase attachmentcsv)
        {
            CsvFileDescription csvFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            CsvContext csvContext = new CsvContext();
            StreamReader streamReader = new StreamReader(attachmentcsv.InputStream);
            IEnumerable<Person> list = csvContext.Read<Person>(streamReader, csvFileDescription);
            foreach (var item in list)
            {
                mgr.AddPerson(item.First_Name, item.Last_Name, item.District, item.Level, item.Gender, item.Twitter, item.Site, item.DateOfBirth, item.Facebook, item.Postal_Code, item.Full_Name, item.Position, item.Organisation, item.Town);
            }
            return Redirect("Personen");
        }
        [HttpPost]
        public ActionResult CSVOpladenOrganisatie(HttpPostedFileBase attachmentcsv)
        {
            CsvFileDescription csvFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            CsvContext csvContext = new CsvContext();
            StreamReader streamReader = new StreamReader(attachmentcsv.InputStream);
            IEnumerable<Person> list = csvContext.Read<Person>(streamReader, csvFileDescription);
            foreach (var item in list)
            {
                mgr.AddPerson(item.First_Name, item.Last_Name, item.District, item.Level, item.Gender, item.Twitter, item.Site, item.DateOfBirth, item.Facebook, item.Postal_Code, item.Full_Name, item.Position, item.Organisation, item.Town);
            }
            return Redirect("Personen");
        }

        [HttpPost]
        public void UpdateFollow(int id)
        {
            accountManager.UpdateFollow(User.Identity.GetUserId(), id);
        }
    }
}