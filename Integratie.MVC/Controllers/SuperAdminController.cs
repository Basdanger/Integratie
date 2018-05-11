using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class SuperAdminController : Controller
    {
        private AccountManager mgr = new AccountManager();
        // GET: SuperAdmin
        public ActionResult GetAdmins()
        {
            IEnumerable<Account> accounts = mgr.GetAccounts();
            return View(accounts);
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