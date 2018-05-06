using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Integratie.MVC.Test.Controllers.Api
{
    public class AndroidController : ApiController
    {
        private static List<string> politiekers = new List<string> { "Bart De Wever", "Elio di Rupo", "Maggie de Block" };

        [HttpGet]
        public IHttpActionResult GetPolById(int id)
        {
            string politieker = politiekers[id];
            if (politieker == null)
            {
                return NotFound();
            }
            return Ok(politieker);
        }

        [HttpPost]
        public IHttpActionResult PostPol(int index, string tekst) {
            return Ok(tekst);
        } 
    }
}
