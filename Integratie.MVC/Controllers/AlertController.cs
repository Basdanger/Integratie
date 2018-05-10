using Integratie.BL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class AlertController : Controller
    {
        // GET: Alert
        AlertManager manager = new AlertManager();
        public ActionResult Index()
        {
            return View(manager.GetAllAlerts());
        }
    }
}