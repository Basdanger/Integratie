using Integratie.BL.Managers;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        SubjectManager subjectManager = new SubjectManager();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemaConfig()
        {
            IEnumerable<Theme> themas=subjectManager.GetThemas();
            return View(themas);
        }

        public ActionResult CreateTheme() {
            var theme = new Theme();
           
            return View(theme);
        }

        [HttpPost]
        public ActionResult CreateTheme(Theme thema)
        {
            
            subjectManager.AddTheme(thema);
            return RedirectToAction("EditTheme", new { id=thema.ID });
            
            
            //subjectManager.AddTheme(thema);
            //return RedirectToAction("ThemaConfig");

       }

        public ActionResult EditTheme(int id) {
            Theme thema = subjectManager.GetThemeById(id);
            return View(thema);
        }

    }
}