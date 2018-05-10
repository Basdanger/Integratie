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
    public class AlertPartialController : Controller
    {
        AlertManager alertManager = new AlertManager();
        // GET: AlertPartial
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _CheckAlert(int id)
        {
            CheckAlert alert = (CheckAlert)alertManager.GetAlertById(id);
            ViewBag.Operator = alert.Operator.GetOperator();
            ViewBag.Property = alert.SubjectProperty.GetSubject();
            return PartialView(alert);
        }

        public ActionResult _TrendAlert(int id)
        {
            return PartialView(alertManager.GetAlertById(id));
        }

        public ActionResult _CompareAlert(int id)
        {
            CompareAlert alert = (CompareAlert)alertManager.GetAlertById(id);
            ViewBag.Operator = alert.Operator.GetOperator();
            return PartialView(alert);
        }

        public ActionResult _SentimentAlert(int id)
        {
            SentimentAlert alert = (SentimentAlert)alertManager.GetAlertById(id);
            ViewBag.Operator = alert.Operator.GetOperator();
            ViewBag.Property = alert.SubjectProperty.GetSubject();
            return PartialView(alert);
        }

        public ActionResult _CheckUserAlerts()
        {
            return PartialView(alertManager.GetUserCheckAlertsOfUser(User.Identity.GetUserId()));
        }

        public ActionResult _TrendUserAlerts()
        {
            return PartialView(alertManager.GetUserTrendAlertsOfUser(User.Identity.GetUserId()));
        }

        public ActionResult _CompareUserAlerts()
        {
            return PartialView(alertManager.GetUserCompareAlertsOfUser(User.Identity.GetUserId()));
        }

        public ActionResult _SentimentUserAlerts()
        {
            return PartialView(alertManager.GetUserSentimentAlertsOfUser(User.Identity.GetUserId()));
        }

        public ActionResult _AlertPopUp()
        {
            return PartialView();
        }
    }
}