using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Test.Controllers
{
    public class GraphController : Controller
    {
        public ActionResult _LineGraphCompare(string id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        public ActionResult _BarGraphCompare(string id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        public ActionResult _DoughnutGraph(string id)
        {
            ViewBag.id = id;
            return PartialView();
        }
    }
}