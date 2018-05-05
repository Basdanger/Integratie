using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integratie.BL.Managers;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.MVC.Controllers
{
    public class PersoonController : Controller
    {
        private SubjectManager mgr = new SubjectManager();
        // GET: Persoon
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Personen()
        {
            IEnumerable<Person> personen = mgr.GetPersonen();
            return View(personen);
        }
    }
}