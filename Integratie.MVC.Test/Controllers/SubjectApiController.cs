using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Integratie.MVC.Test.Controllers
{
    public class SubjectApiController : ApiController
    {
        private SubjectManager manager = new SubjectManager();
        [HttpGet]
        public IHttpActionResult GetSubjects()
        {
            var subjects = manager.GetSubjects();
            return Ok(subjects);
        }
        [HttpGet]
        public IHttpActionResult GetPersons()
        {
            var subjects = manager.GetSubjects();
            return Ok(subjects);
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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