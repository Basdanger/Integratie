namespace Integratie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Graph", "PersonFilter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Graph", "PersonFilter");
        }
    }
}
