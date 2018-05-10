using Integratie.BL.Managers;
using Integratie.Domain.Entities.Alerts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class AlertController : Controller
    {
        private AlertManager alertManager = new AlertManager();

        // GET: Alert
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alerts()
        {
            IEnumerable<UserAlert> alerts = alertManager.GetUserAlertsOfUser(User.Identity.GetUserId());
            return View(alerts);
        }
    }
}