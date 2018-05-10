using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
using Integratie.MVC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
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
            //Person person = mgr.GetPersoon(Full_Name);
            return View(pf);
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
    }
}