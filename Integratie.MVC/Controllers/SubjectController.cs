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
            /*PersonandFeeds pf = new PersonandFeeds();
            pf.persons = mgr.GetPersoon(Full_Name);
            pf.feeds = mgr.GetFeeds(Full_Name);
            //Person person = mgr.GetPersoon(Full_Name);
            return View(pf);*/
            return null;
        }
        public ActionResult Organisaties()
        {
            IEnumerable<Organisation> organisaties = mgr.GetOrganisaties();
            return View(organisaties);
        }
    }
}