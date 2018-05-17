using Integratie.BL.Managers;
using Integratie.Domain.Entities;
using Integratie.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context;
        RoleController rc = new RoleController();
        public AdminController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUsers(string roleName = "User")
        {
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            IQueryable<ApplicationUser> users = null;
            if (roleManager.RoleExists("User"))
            {
                var idsWithPermission = roleManager.FindByName("User").Users.Select(iur => iur.UserId);
                users = context.Users.Where(u => idsWithPermission.Contains(u.Id));
            }
            return View(users);
        }
        public ActionResult GetUser(String username)
        {
            var user= context.Users.Where(u => u.UserName.Equals(username)).First();
            return View(user);
        }
        public ActionResult DeleteUser(String username)
        {
            var user = context.Users.Where(u => u.UserName.ToUpper().Equals(username)).First();
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(ApplicationUser applicationUser, FormCollection collection)
        {
            try
            {
                context.Users.Remove(applicationUser);
                context.SaveChanges();
                return RedirectToAction("GetUsers");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult UpdateUser(String username)
        {
            var user = context.Users.Where(u => u.UserName.Equals(username)).First();
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(ApplicationUser applicationUser, FormCollection collection)
        {
            context.Entry(applicationUser).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("GetUsers");
        }

        public void ExportToCSV()
        {
            StringWriter sw = new StringWriter();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachement; filename=ExportedUsersList.csv");
            Response.ContentType = "text/csv";

            //var users = GetUsers();
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            IQueryable<ApplicationUser> users = null;
            if (roleManager.RoleExists("User"))
            {
                var idsWithPermission = roleManager.FindByName("User").Users.Select(iur => iur.UserId);
                users = context.Users.Where(u => idsWithPermission.Contains(u.Id));
            }
            foreach (var item in users)
            {
                sw.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", item.UserName, item.FirstName, item.LastName, item.Id));
            }
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}