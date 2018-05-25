using Integratie.BL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class TeslaBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ContentManager cm = new ContentManager();
            ViewBag.SiteTitle = cm.GetContentByKey("SiteTitle").Value;
            ViewBag.PrimaryColor = cm.GetContentByKey("PrimaryColor").Value;
            ViewBag.SecondaryColor = cm.GetContentByKey("SecondaryColor").Value;
            ViewBag.TertiaryColor = cm.GetContentByKey("TertiaryColor").Value;

            ViewBag.IndexTitle = cm.GetContentByKey("IndexTitle").Value;
            ViewBag.IndexContent = cm.GetContentByKey("IndexContent").Value;
            ViewBag.AlertAlias = cm.GetContentByKey("AlertAlias").Value;
            ViewBag.AlertContent = cm.GetContentByKey("AlertContent").Value;
            ViewBag.ThemeAlias = cm.GetContentByKey("ThemeAlias").Value;
            ViewBag.ThemeContent = cm.GetContentByKey("ThemeContent").Value;
            ViewBag.PersonAlias = cm.GetContentByKey("PersonAlias").Value;
            ViewBag.PersonContent = cm.GetContentByKey("PersonContent").Value;
            ViewBag.OrganisationAlias = cm.GetContentByKey("OrganisationAlias").Value;
            ViewBag.OrganisationContent = cm.GetContentByKey("OrganisationContent").Value;
            ViewBag.FAQTitle = cm.GetContentByKey("FAQTitle").Value;
            ViewBag.FAQContent = cm.GetContentByKey("FAQContent").Value;
            ViewBag.ContactTitle = cm.GetContentByKey("ContactTitle").Value;
            ViewBag.ContactContent = cm.GetContentByKey("ContactContent").Value;
            ViewBag.PrivacyTitle = cm.GetContentByKey("PrivacyTitle").Value;
            ViewBag.PrivacyContent = cm.GetContentByKey("PrivacyContent").Value;
            base.OnActionExecuted(filterContext);
        }
    }
}