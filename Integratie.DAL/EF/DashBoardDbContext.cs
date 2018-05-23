using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Alerts;
using Integratie.Domain.Entities.Content;
using Integratie.Domain.Entities.Dashboard;
using Integratie.Domain.Entities.Graph;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    [DbConfigurationType(typeof(DashboardDbConfiguration))]
    public class DashBoardDbContext : DbContext
    {
        private readonly bool delaySave;

        public DashBoardDbContext() : base("name=IntegratieDB")
        {
            Database.SetInitializer<DashBoardDbContext>(new DashboardDbInitializer());
            delaySave = false;
        }

        public DashBoardDbContext(bool unitOfWork = false) : base("name=IntegratieDB")
        {
            Database.SetInitializer<DashBoardDbContext>(new DashboardDbInitializer());
            delaySave = unitOfWork;
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Graph> Graphs { get; set; }
        public DbSet<DashboardItem> Dashboarditems { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<UserAlert> UserAlerts { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<SiteContent> SiteContents{ get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<TermMention> TermMentions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Graph>()
            .Property(f => f.EndDate)
            .HasColumnType("datetime2");
            modelBuilder.Entity<Graph>()
            .Property(f => f.StartDate)
            .HasColumnType("datetime2");

            modelBuilder.Entity<Alert>().HasKey(a => a.AlertID);

            modelBuilder.Entity<DashboardItem>()
                .HasOptional<Graph>(s => s.Graph)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);
        }

        public override int SaveChanges()
        {
            if (delaySave) return -1;
            return base.SaveChanges();
        }

        internal int CommitChanges()
        {
            if (delaySave)
            {
                return base.SaveChanges();
            }
            throw new InvalidOperationException("No UnitOfWork present, use SaveChanges instead");
        }
    }
}
