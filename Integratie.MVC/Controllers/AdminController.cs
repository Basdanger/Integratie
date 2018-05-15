using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using Integratie.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class AdminController : Controller
    {
        private AccountManager mgr = new AccountManager();
        RoleController rc = new RoleController();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUsers()
        {
            IEnumerable<ApplicationUser> accounts = rc.GetUsers();
            return View(accounts);
        }
        public ActionResult GetUser(int id)
        {
            ApplicationUser user = rc.GetUser(id);
            return View(user);
        }
        public void ExportToCSV()
        {
            StringWriter sw = new StringWriter();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachement; filename=ExportedUsersList.csv");
            Response.ContentType = "text/csv";

            var users = mgr.GetAccounts();

            foreach (var item in users)
            {
                sw.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", item.ID, item.Name, item.Mail, item.Password));
            }
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}