using Integratie.BL.Managers;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class ThemeController : Controller
    {
        ThemeManager themeManager = new ThemeManager();
        // GET: Theme
        public ActionResult Index()
        {
            IEnumerable<Theme> themas=themeManager.GetThemas();
            return View(themas);
        }

       
    }
}
