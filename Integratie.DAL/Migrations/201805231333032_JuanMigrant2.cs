namespace Integratie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JuanMigrant2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Graph", "PartijFilter", c => c.String());
            AddColumn("dbo.Graph", "ThemeFilter", c => c.String());
            AddColumn("dbo.Graph", "SentimentStart", c => c.Double(nullable: false));
            AddColumn("dbo.Graph", "SentimentEnd", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Graph", "SentimentEnd");
            DropColumn("dbo.Graph", "SentimentStart");
            DropColumn("dbo.Graph", "ThemeFilter");
            DropColumn("dbo.Graph", "PartijFilter");
        }
    }
}
