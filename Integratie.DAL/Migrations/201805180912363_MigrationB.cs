namespace Integratie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteContent",
                c => new
                    {
                        IdKey = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.IdKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteContent");
        }
    }
}
