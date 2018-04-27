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
        public IHttpActionResult GetPolById(int id) {
            string politieker = politiekers[id];
            if (politieker == null) {
                return NotFound();
            }
            return Ok(politieker);
        }

        [HttpGet]
        public IHttpActionResult GetAllPols() {
            return Ok(politiekers);
        }

        [HttpPost]
        public IHttpActionResult PostSomething([FromBody] string politieker) {
            politiekers.Add(politieker);
            return CreatedAtRoute("DefaultApi",new { controller = "AlertAPITest", id = politiekers.IndexOf(politieker) },politieker);
        }

        [HttpPut]
        public IHttpActionResult PutDeviceId(string deviceId, string userId) {


            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


    }
}
