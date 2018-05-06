using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
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
            dynamic myModel = new ExpandoObject();
            myModel.Personen = mgr.GetPersoon(Full_Name);
            myModel.Feeds = mgr.GetFeeds(Full_Name);
            Person person = mgr.GetPersoon(Full_Name);
            return View(myModel);
        }
        public ActionResult Organisaties()
        {
            IEnumerable<Organisation> organisaties = mgr.GetOrganisaties();
            return View(organisaties);
        }
    }
}