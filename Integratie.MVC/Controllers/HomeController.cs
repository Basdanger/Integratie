using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CSV()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload_file(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Upload"), Path.GetFileName(file.FileName));
                    string pad = "C:\\Users\\yanni\\OneDrive\\Documenten\\Yannis School\\P2\\NET\\lol";
                    file.SaveAs(pad);
                    ViewBag.Message = "file uploaded succesfully";
                }catch(Exception ex)
                {
                    ViewBag.Message = "ERROR, file not uploaded";
                }
            }
            else
            {
                ViewBag.Message = "Please select file";
            }
            return View();
        }

        public ActionResult Gemeente()
        {
            ViewBag.Message = "Your Towns Page";
            string[] gemeentes = { "Aartselaar", "Antwerpen", "Arendonk", "Baarle-Hertog", "Balen", "Beerse", "Berleer", "Boechout", "Bonheiden" };

            return View(gemeentes);
        }

        public ActionResult Politici()
        {
            // Person person = mgr.getPerson();
            // Geef person mee aan view...
            return View(new String[] { "Bart De Wever", "Bart De Wever", "Bart De Wever", "Bart De Wever", "Bart De Wever", "Bart De Wever", "Bart De Wever", "Bart De Wever" });
        }

        public ActionResult Politieker()
        {
            return View();
        }

        public ActionResult WeeklyReview()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Organisatie()
        {
            return View();
        }

        public ActionResult GemeentePage(string Gemeente) {


            return View((object)Gemeente);
        }
    }
}