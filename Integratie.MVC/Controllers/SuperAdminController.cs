using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
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
    }
}