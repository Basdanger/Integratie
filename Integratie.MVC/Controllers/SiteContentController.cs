using Integratie.BL.Managers;
using Integratie.Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class SiteContentController : TeslaBaseController
    {
        ContentManager cm = new ContentManager();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult Index(List<SiteContent> SiteContents)
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
            return Redirect("Index");
        }
    }
}