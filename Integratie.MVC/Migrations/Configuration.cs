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
                var role = new IdentityRole();
                role.Name = "Admin";
                rolemanager.Create(role);
            }

            if (!rolemanager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                rolemanager.Create(role);
            }

            if (!(context.Users.Any(u => u.Email == "admin@tesla.be")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    Email = "admin@tesla.be",
                    UserName = "TeslaAdmin",
                    FirstName = "",
                    LastName = "",
                };
                userManager.Create(user, "Test1234(");
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
        }
    }
}
