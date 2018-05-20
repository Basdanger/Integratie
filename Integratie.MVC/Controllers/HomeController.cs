using Integratie.BL.Managers;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Dashboard;
using Integratie.Domain.Entities.Graph;
using Integratie.Domain.Entities.Subjects;
using Integratie.MVC.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
namespace Integratie.MVC.Controllers
{
    public class HomeController : Controller
    {
        GraphManager manager = new GraphManager();
        DashboardManager dbmanager = new DashboardManager();
        SubjectManager subjectManager = new SubjectManager();
        AlertManager alertManager = new AlertManager();
        private SubjectManager subjectmgr = new SubjectManager();
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.persons = subjectManager.GetPersonen().Select(p => p.Full_Name);
            List<DashboardItem> dbitems = dbmanager.GetAllDashboardItems();
            return View(dbitems);
        }

        [HttpPost]
        public ActionResult Index(List<DashboardItem> dbis)
        {
            dbmanager.UpdateDashboard(dbis);
            List<DashboardItem> dbitems = dbmanager.GetAllDashboardItems();
            //foreach (DashboardItem dbi in dbis)
            //{
            //    dbi.Graph = dbitems.ToList().Where(e => e.Id == dbi.Id).First().Graph;
            //}
            //dbmanager.Update(dbis);
            //dbitems = dbmanager.GetAllDashboardItems();

            ViewBag.persons = subjectManager.GetPersonen().Select(p => p.Full_Name);
            return View(dbitems);
        }
       [HttpPost]
        public ActionResult RemoveDashboardItem(DashboardItem dbi)
        {
            dbmanager.RemoveDashboardItem(dbi);
            List<DashboardItem> dbitems = dbmanager.GetAllDashboardItems();
            ViewBag.persons = subjectManager.GetPersonen().Select(p => p.Full_Name);
            return View(dbitems);
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
        public ActionResult AddGraph(Graph graph)
        {
            DashboardItem dbi = new DashboardItem(0, 1, 1000, 3, 2, graph);
            dbmanager.AddDashboardItem(dbi);
            List<DashboardItem> dbitems = dbmanager.GetAllDashboardItems();
            return View(dbitems);
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

        public ActionResult GemeentePage(string gemeente) {
            SubjectManager subjectmngr = new SubjectManager();
            IEnumerable<Subject> people=subjectmngr.GetPeopleByTown(gemeente);
            return View(people);
        }

        public ActionResult Alerts()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUserAlert(AlertCreation alert)
        {
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Alerts", "Home", new { });

            try
            {
                alertManager.AddUserAlert(User.Identity.GetUserId(), alert.AlertType, alert.Subject, alert.Web, alert.Mail, alert.App, alert.SubjectB, alert.Compare, alert.SubjectProperty, alert.Value);
            }
            catch (Exception)
            {
                return Json(new { Url = redirectUrl, status = "Error" });
            }

            return Json(new { Url = redirectUrl, status = "OK" });
        }

        [HttpPost]
        public void UpdateUserAlert(AlertUpdate alert)
        {
            alertManager.UpdateUserAlert(alert.Id, alert.Web, alert.Mail, alert.App);
        }

        [HttpPost]
        public void RemoveUserAlert(int id)
        {
            alertManager.RemoveUserAlert(id);
        }
        public ActionResult Search(String zoek)
        {
            Search search = new Search();
            search.person = subjectmgr.GetPersonen().Where(pers => pers.Full_Name.ToUpper().Equals(zoek)).First();
            return View(search);
        }
    }
}