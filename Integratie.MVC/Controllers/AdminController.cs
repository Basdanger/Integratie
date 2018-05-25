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
    [Authorize(Roles = "Admin")]
    public class AdminController : TeslaBaseController
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

        //public ActionResult DeleteUser(string id)
        //{
        //    //ApplicationUser user = _userManager.FindByName(username);
        //    //var user = _userManager.FindById(id);
        //    var user = context.Users.Find(id);
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //DeleteUserViewModel model = new DeleteUserViewModel() { Id = id };
        //    return View(user);
        //}

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //get User Data from Userid
            var user = await UserManager.FindByIdAsync(id);

            //List Logins associated with user
            var logins = user.Logins;

            //Gets list of Roles associated with current user
            var rolesForUser = await UserManager.GetRolesAsync(id);

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        // item should be the name of the role
                        var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }

                //Delete User
                await UserManager.DeleteAsync(user);

                TempData["Message"] = "User Deleted Successfully. ";
                TempData["MessageValue"] = "1";
                //transaction.commit();
            }

            return RedirectToAction("GetUsers", "Admin", new { area = "", });
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