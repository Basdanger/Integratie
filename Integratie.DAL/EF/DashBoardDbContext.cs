using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    [DbConfigurationType(typeof(DashboardDbConfiguration))]
    public class DashBoardDbContext : DbContext
    {
        public DashBoardDbContext() : base("IntegratieDB")
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
