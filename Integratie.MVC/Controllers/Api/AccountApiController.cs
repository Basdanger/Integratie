using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Integratie.MVC.Controllers.Api
{
    public class AccountApiController : ApiController
    {
        private AccountController accController;
        private AccountManager accManager;

        public AccountApiController()
        {
            accController = new AccountController();
            accManager = new AccountManager();
        }

        public IHttpActionResult GetUsers()
        {
            var users = accManager.GetAccounts();
            return Ok(users);
        }

            //var zoekUser = await UserManager.FindByIdAsync(user.Id);

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

        //DeviceId toevoegen
        public void PutDeviceId(string id, string deviceId) {
            Account account=accManager.GetAccountById(id);
            account.DeviceId = (deviceId);
            accManager.ChangeAccount(account);
        }
    }
}