using Integratie.BL.Managers;
using Integratie.Domain.Entities.Graph;
using Newtonsoft.Json;
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
            List<Graph> Graphs = manager.GetAllFilledGraphs();
            return View(Graphs);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            //List<double> listValues = new List<double>();
            //List<string> listKeys = new List<string>();
            //BarChartGraph graph = (BarChartGraph)manager.GetAllFilledGraphs().First();
            //graph.Values.Values.ToList().ForEach(i => listValues.Add(i));
            //graph.Values.Keys.ToList().ForEach(i => listKeys.Add(i));
            //ViewBag.DataValues = JsonConvert.SerializeObject(listValues);
            //ViewBag.DataKeys = JsonConvert.SerializeObject(listKeys);
            return View();
        }
    }
}