using Integratie.BL.Managers;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Integratie.MVC.Controllers
{
    public class PersoonController : Controller
    {
        private SubjectManager manager = new SubjectManager();
        // GET: Persoon
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Personen()
        {
            IEnumerable<Person> subjects = manager.GetPersons();
            return View(subjects);
        }
    }
}