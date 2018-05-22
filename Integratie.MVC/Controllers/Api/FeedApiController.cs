using Integratie.BL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Integratie.MVC.Controllers.Api
{
    public class FeedApiController : ApiController
    {
        private FeedManager mgr;
        public FeedApiController()
        {
            mgr = new FeedManager();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //[HttpGet]
        //public IHttpActionResult GetLocaties()
        //{
        //    var locaties = mgr.getFeedLocaties();
        //    return Ok(locaties);
        //}
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}