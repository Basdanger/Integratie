namespace Integratie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationA : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subject", "BarChartGraph_GraphId", "dbo.Graph");
            DropIndex("dbo.Subject", new[] { "BarChartGraph_GraphId" });
            DropColumn("dbo.Subject", "BarChartGraph_GraphId");
            DropColumn("dbo.Graph", "Period");
            DropColumn("dbo.Graph", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Graph", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Graph", "Period", c => c.Int());
            AddColumn("dbo.Subject", "BarChartGraph_GraphId", c => c.Int());
            CreateIndex("dbo.Subject", "BarChartGraph_GraphId");
            AddForeignKey("dbo.Subject", "BarChartGraph_GraphId", "dbo.Graph", "GraphId");
        }
    }
}
