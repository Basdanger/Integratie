namespace Integratie.MVC.Migrations
{
    using Integratie.MVC.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Integratie.MVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Integratie.MVC.Models.ApplicationDbContext";
        }

        protected override void Seed(Integratie.MVC.Models.ApplicationDbContext context)
        {
            var rolestore = new RoleStore<IdentityRole>(context);
            var rolemanager = new RoleManager<IdentityRole>(rolestore);

            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var role = new IdentityRole
                {
                    Name = "SuperAdmin"
                };

                rolemanager.Create(role);
            }

            if (!rolemanager.RoleExists("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                rolemanager.Create(role);
            }

            if (!rolemanager.RoleExists("User"))
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                rolemanager.Create(role);
            }

            if (!(context.Users.Any(u => u.Email == "admin@tesla.be")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var superAdmin = new ApplicationUser
                {
                    Email = "admin@tesla.be",
                    UserName = "TeslaAdmin",
                    FirstName = "",
                    LastName = "",
                };
                userManager.Create(superAdmin, "Test1234(");
                userManager.AddToRole(superAdmin.Id, "SuperAdmin");

                #region admins
                var adminJorne = new ApplicationUser
                {
                    Email = "jorne@tesla.be",
                    UserName = "Jorne",
                    FirstName = "Jorne",
                    LastName = "Reynders"
                };
                userManager.Create(adminJorne, "Test1234(");
                userManager.AddToRole(adminJorne.Id, "Admin");

                var adminNikolaas = new ApplicationUser
                {
                    Email = "nikolaas@tesla.be",
                    UserName = "Nikolaas",
                    FirstName = "Nikolaas",
                    LastName = "De Burggrave"
                };
                userManager.Create(adminNikolaas, "Test1234(");
                userManager.AddToRole(adminNikolaas.Id, "Admin");

                var adminTiboo = new ApplicationUser
                {
                    Email = "tiboo@tesla.be",
                    UserName = "Tiboo",
                    FirstName = "Tiboo",
                    LastName = "Augustijnen"
                };
                userManager.Create(adminTiboo, "Test1234(");
                userManager.AddToRole(adminTiboo.Id, "Admin");

                var adminMarnick = new ApplicationUser
                {
                    Email = "marnick@tesla.be",
                    UserName = "Marnick",
                    FirstName = "Marnick",
                    LastName = "Huysmans"
                };
                userManager.Create(adminMarnick, "Test1234(");
                userManager.AddToRole(adminMarnick.Id, "Admin");

                var adminJan = new ApplicationUser
                {
                    Email = "jan@tesla.be",
                    UserName = "Jan",
                    FirstName = "Jan",
                    LastName = "van Hoye"
                };
                userManager.Create(adminJan, "Test1234(");
                userManager.AddToRole(adminJan.Id, "Admin");

                var adminYannis = new ApplicationUser
                {
                    Email = "yannis@tesla.be",
                    UserName = "Yannis",
                    FirstName = "Yannis",
                    LastName = "Arnouts"
                };
                userManager.Create(adminYannis, "Test1234(");
                userManager.AddToRole(adminYannis.Id, "Admin");
                #endregion

                #region user
                var user = new ApplicationUser
                {
                    Email = "bob@detester.be",
                    UserName = "Bob De Tester",
                    FirstName = "Bob",
                    LastName = "De Tester",
                };
                userManager.Create(user, "Test1234(");
                userManager.AddToRole(user.Id, "User");
                #endregion
            }
        }
    }
}
