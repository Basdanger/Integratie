using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Integratie.MVC.Test.Controllers.Api
{
    public class AlertAPITestController : ApiController
    {
        private static List<string> politiekers = new List<string> { "Bart De Wever", "Elio di Rupo","Maggie de Block"};
        
        [HttpGet]
        public string GetPolById(int id) {
            return politiekers[id];
        }

        [HttpGet]
        public IEnumerable<string> GetAllPols() {
            return politiekers;
        }


    }
}
