using Integratie.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Integratie.MVC.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context;
        RoleController rc = new RoleController();
        private ApplicationUserManager _userManager;
        public AdminController()
        {
            context = new ApplicationDbContext();
        }
        public AdminController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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
            var user = context.Users.Where(u => u.UserName.Equals(username)).First();
            return View(user);
        }
        public ActionResult DeleteUser(string id)
        {
            //ApplicationUser user = _userManager.FindByName(username);
            //var user = _userManager.FindById(id);
            var user = context.Users.Find(id);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //DeleteUserViewModel model = new DeleteUserViewModel() { Id = id };
            return View(user);
        }
        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(DeleteUserViewModel model, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var user = _userManager.FindById(id);
            var user = context.Users.Find(model.Id);
            var logins = user.Logins;
            //var rolesForUser = context.Roles.Where(r => r.Users.Where(u => u.UserId).Equals(user.Id));
            var rolesForUser = await _userManager.GetRolesAsync(user.Id);

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await _userManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        // item should be the name of the role
                        var result = await _userManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }

                await _userManager.DeleteAsync(user);
                transaction.Commit();
            }

            return RedirectToAction("GetUsers");
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