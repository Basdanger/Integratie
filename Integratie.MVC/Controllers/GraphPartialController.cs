using Integratie.BL.Managers;
using Integratie.Domain.Entities.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class GraphPartialController : Controller
    {
        GraphManager graphManager = new GraphManager();
        // GET: GraphPartial
        public ActionResult _BarChart(int id)
        {
            //ViewBag.id = id;
            //BarChartGraph graph = graphManager.GetBarChartGraph(id);
            //List<double> listValues = graph.Values.Values.ToList();
            //List<string> listKeys = graph.Values.Keys.ToList();
            //ViewBag.Values = JsonConvert.SerializeObject(listValues);
            //ViewBag.Keys = JsonConvert.SerializeObject(listKeys);
            return PartialView();
        }

        public ActionResult _PieChart(int id)
        {
            //ViewBag.id = id;
            //PieGraph graph = graphManager.GetPieGraph(id);
            //List<double> listValues = graph.Values.Values.ToList();
            //List<string> listKeys = graph.Values.Keys.ToList();
            //ViewBag.Values = JsonConvert.SerializeObject(listValues);
            //ViewBag.Keys = JsonConvert.SerializeObject(listKeys);
            return PartialView();
        }
    }
}