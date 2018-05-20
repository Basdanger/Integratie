using Integratie.BL.Managers;
using Integratie.Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class SiteContentController : Controller
    {
        ContentManager cm = new ContentManager();
        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.SiteTitle = cm.GetContentByKey("SiteTitle").Value;
            ViewBag.PrimaryColor = cm.GetContentByKey("PrimaryColor").Value;
            ViewBag.SecondaryColor = cm.GetContentByKey("SecondaryColor").Value;

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

            return View();
        }
        [HttpPost]
        public EmptyResult Index(List<SiteContent> SiteContents)
        {
            //try
            //{
                SiteContents.ForEach(sc => cm.UpdateSiteContent(sc));
                Response.StatusCode = 200;
            //}
            //catch
            //{
            //    Response.StatusCode = 500;
            //}
            return null;
        }
    }
}