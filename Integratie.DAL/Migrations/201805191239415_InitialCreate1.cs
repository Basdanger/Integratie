namespace Integratie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoryString = c.String(),
                        Date = c.DateTime(nullable: false),
                        Titel = c.String(),
                        Link = c.String(),
                        Theme_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.Theme_ID)
                .Index(t => t.Theme_ID);
            
            CreateTable(
                "dbo.TermMention",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Term = c.String(),
                        Count = c.Int(nullable: false),
                        Theme_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.Theme_ID)
                .Index(t => t.Theme_ID);
            
            AddColumn("dbo.Subject", "Terms", c => c.String());
            AddColumn("dbo.Subject", "Image", c => c.Binary());
            AddColumn("dbo.Subject", "TopPersons", c => c.String());
            AddColumn("dbo.Subject", "TopOrganisations", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TermMention", "Theme_ID", "dbo.Subject");
            DropForeignKey("dbo.Story", "Theme_ID", "dbo.Subject");
            DropIndex("dbo.TermMention", new[] { "Theme_ID" });
            DropIndex("dbo.Story", new[] { "Theme_ID" });
            DropColumn("dbo.Subject", "TopOrganisations");
            DropColumn("dbo.Subject", "TopPersons");
            DropColumn("dbo.Subject", "Image");
            DropColumn("dbo.Subject", "Terms");
            DropTable("dbo.TermMention");
            DropTable("dbo.Story");
        }
    }
}
