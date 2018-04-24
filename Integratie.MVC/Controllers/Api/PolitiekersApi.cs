using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Integratie.BL.Managers.Interfaces;
using Integratie.BL.Managers;
using Integratie.Domain.Entities;

namespace Integratie.MVC.Controllers.Api
{
    public class PolitiekersApi : ApiController
    {
        private IFeedManager mgr = new FeedManager();
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Feed> Get()
        {
            var feeds = mgr.GetFeeds();
            return feeds;
        }

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