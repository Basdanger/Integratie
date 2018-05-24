using Integratie.BL.Managers;
using Integratie.Domain.Entities.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class IndexController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            GraphManager manager = new GraphManager();
            ViewBag.graphA = manager.GetFilledSingleTrendGraph(new Graph { PersonFilter = "Bart De Wever", PeriodSort = PeriodSort.Flex, PeriodLength = 5, SentimentStart = -1, SentimentEnd = 1 });
            ViewBag.graphB = manager.GetFilledSingleTrendGraph(new Graph { PersonFilter = "Maggie De Block", PeriodSort = PeriodSort.Flex, PeriodLength = 5, SentimentStart = -1, SentimentEnd = 1 });
            ViewBag.graphC = manager.GetFilledSingleTrendGraph(new Graph { PersonFilter = "Theo Francken", PeriodSort = PeriodSort.Flex, PeriodLength = 5, SentimentStart = -1, SentimentEnd = 1 });
            return View();
        }
    }
}
