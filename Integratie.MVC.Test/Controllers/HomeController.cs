using Integratie.BL.Managers;
using Integratie.Domain.Entities.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Test.Controllers
{
    public class HomeController : Controller
    {
        GraphManager manager = new GraphManager();
        public ActionResult Index()
        {
            ViewBag.Message = "Graphcount : " + manager.GetGraphCount() ;
            List<Graph> Graphs = manager.GetAllFilledGraphs();
            return View(Graphs);
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
    }
}