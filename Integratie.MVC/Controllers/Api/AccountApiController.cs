using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Integratie.BL.Managers;

namespace Integratie.MVC.Controllers.Api
{
    public class AccountApiController : ApiController
    {
        private AccountManager mgr = new AccountManager();
        // GET api/<controller>
        [HttpGet]
        //[Authorize]
        public IHttpActionResult GetAccounts()
        {
            var accounts = mgr.GetAccounts();
            return Ok(accounts);
        }
        [HttpGet]
        //[Authorize]
        public IHttpActionResult GetAccount()
        {
            var accounts = mgr.GetAccounts();
            return Ok(accounts);
        }
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