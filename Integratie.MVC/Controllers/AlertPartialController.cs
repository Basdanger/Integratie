using Integratie.BL.Managers;
using Integratie.Domain.Entities.Alerts;
using Integratie.MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class AlertPartialController : TeslaBaseController
    {
        AlertManager alertManager = new AlertManager();
        SubjectManager subjectManager = new SubjectManager();

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
            return PartialView(alertManager.GetUserCheckAlertsOfUser(User.Identity.GetUserId()).ToList());
        }

        public ActionResult _TrendUserAlerts()
        {
            return PartialView(alertManager.GetUserTrendAlertsOfUser(User.Identity.GetUserId()).ToList());
        }

        public ActionResult _CompareUserAlerts()
        {
            return PartialView(alertManager.GetUserCompareAlertsOfUser(User.Identity.GetUserId()).ToList());
        }

        public ActionResult _SentimentUserAlerts()
        {
            return PartialView(alertManager.GetUserSentimentAlertsOfUser(User.Identity.GetUserId()).ToList());
        }

        public ActionResult _AlertPopUp()
        {
            return PartialView(subjectManager.GetSubjectNames());
        }

        public ActionResult _SentimentAlertDropDown(SentimentAlert alert)
        {
            ViewBag.Operator = alert.Operator.GetOperator();
            ViewBag.Property = alert.SubjectProperty.GetSubject();
            return PartialView(alert);
        }

        public ActionResult _CompareAlertDropDown(CompareAlert alert)
        {
            ViewBag.Operator = alert.Operator.GetOperator();
            return PartialView(alert);
        }

        public ActionResult _CheckAlertDropDown(CheckAlert alert)
        {
            ViewBag.Operator = alert.Operator.GetOperator();
            ViewBag.Property = alert.SubjectProperty.GetSubject();
            return PartialView(alert);
        }

        public ActionResult _TrendAlertDropDown(TrendAlert alert)
        {
            return PartialView(alert);
        }
    }
}