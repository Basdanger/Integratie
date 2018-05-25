using Integratie.BL.Managers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class SharedController : TeslaBaseController
    {
        AlertManager alertManager = new AlertManager();

        public ActionResult _AlertDropDown()
        {
            return PartialView(alertManager.GetUserAlertsOfUser(User.Identity.GetUserId()));
        }
    }
}