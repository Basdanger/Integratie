namespace Integratie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JuanMigrant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                        DeviceId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FeedCount = c.Int(nullable: false),
                        Trending = c.Boolean(nullable: false),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        District = c.String(),
                        Level = c.String(),
                        Gender = c.String(),
                        Twitter = c.String(),
                        Site = c.String(),
                        DateOfBirth = c.DateTime(),
                        Facebook = c.String(),
                        Postal_Code = c.String(),
                        Full_Name = c.String(),
                        Position = c.String(),
                        Organisation = c.String(),
                        Town = c.String(),
                        Terms = c.String(),
                        Image = c.Binary(),
                        TopPersons = c.String(),
                        TopOrganisations = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Account_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Account_ID)
                .Index(t => t.Account_ID);
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoryString = c.String(),
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
            
            CreateTable(
                "dbo.Alert",
                c => new
                    {
                        AlertID = c.Int(nullable: false, identity: true),
                        JsonValues = c.String(),
                        SubjectProperty = c.Int(),
                        Operator = c.Int(),
                        Value = c.Int(),
                        Operator1 = c.Int(),
                        SubjectProperty1 = c.Int(),
                        Operator2 = c.Int(),
                        Value1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Graph_GraphId = c.Int(),
                        Subject_ID = c.Int(),
                        SubjectA_ID = c.Int(),
                        SubjectB_ID = c.Int(),
                        Subject_ID1 = c.Int(),
                        Subject_ID2 = c.Int(),
                    })
                .PrimaryKey(t => t.AlertID)
                .ForeignKey("dbo.Graph", t => t.Graph_GraphId)
                .ForeignKey("dbo.Subject", t => t.Subject_ID)
                .ForeignKey("dbo.Subject", t => t.SubjectA_ID)
                .ForeignKey("dbo.Subject", t => t.SubjectB_ID)
                .ForeignKey("dbo.Subject", t => t.Subject_ID1)
                .ForeignKey("dbo.Subject", t => t.Subject_ID2)
                .Index(t => t.Graph_GraphId)
                .Index(t => t.Subject_ID)
                .Index(t => t.SubjectA_ID)
                .Index(t => t.SubjectB_ID)
                .Index(t => t.Subject_ID1)
                .Index(t => t.Subject_ID2);
            
            CreateTable(
                "dbo.Graph",
                c => new
                    {
                        GraphId = c.Int(nullable: false, identity: true),
                        GraphType = c.Int(nullable: false),
                        CalcType = c.Int(nullable: false),
                        CompareSort = c.Int(nullable: false),
                        ComparePersons = c.String(),
                        PeriodSort = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PeriodLength = c.Int(nullable: false),
                        StartInterval = c.Double(nullable: false),
                        EndInterval = c.Double(nullable: false),
                        IntervalSize = c.Double(nullable: false),
                        AgeFilter = c.Int(nullable: false),
                        PersonalityFilter = c.Int(nullable: false),
                        PersonFilter = c.String(),
                        GenderFilter = c.Int(nullable: false),
                        Account_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GraphId)
                .ForeignKey("dbo.Account", t => t.Account_ID)
                .Index(t => t.Account_ID);
            
            CreateTable(
                "dbo.DashboardItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Column = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        X_Size = c.Int(nullable: false),
                        Y_Size = c.Int(nullable: false),
                        Graph_GraphId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Graph", t => t.Graph_GraphId, cascadeDelete: true)
                .Index(t => t.Graph_GraphId);
            
            CreateTable(
                "dbo.Feed",
                c => new
                    {
                        ID = c.Double(nullable: false),
                        Profile_Gender = c.Int(nullable: false),
                        Profile_Age = c.String(),
                        Profile_Education = c.String(),
                        Profile_Language = c.String(),
                        Profile_Personality = c.String(),
                        Words = c.String(),
                        Sentiment = c.String(),
                        Source = c.String(),
                        Hashtags = c.String(),
                        Themes = c.String(),
                        Persons = c.String(),
                        Urls = c.String(),
                        Date = c.DateTime(nullable: false),
                        Mentions = c.String(),
                        Geo = c.String(),
                        Retweet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SiteContent",
                c => new
                    {
                        IdKey = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.IdKey);
            
            CreateTable(
                "dbo.UserAlert",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Show = c.Boolean(nullable: false),
                        Web = c.Boolean(nullable: false),
                        Mail = c.Boolean(nullable: false),
                        App = c.Boolean(nullable: false),
                        Account_ID = c.String(maxLength: 128),
                        Alert_AlertID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Account_ID)
                .ForeignKey("dbo.Alert", t => t.Alert_AlertID)
                .Index(t => t.Account_ID)
                .Index(t => t.Alert_AlertID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAlert", "Alert_AlertID", "dbo.Alert");
            DropForeignKey("dbo.UserAlert", "Account_ID", "dbo.Account");
            DropForeignKey("dbo.DashboardItem", "Graph_GraphId", "dbo.Graph");
            DropForeignKey("dbo.Alert", "Subject_ID2", "dbo.Subject");
            DropForeignKey("dbo.Alert", "Subject_ID1", "dbo.Subject");
            DropForeignKey("dbo.Alert", "SubjectB_ID", "dbo.Subject");
            DropForeignKey("dbo.Alert", "SubjectA_ID", "dbo.Subject");
            DropForeignKey("dbo.Alert", "Subject_ID", "dbo.Subject");
            DropForeignKey("dbo.Alert", "Graph_GraphId", "dbo.Graph");
            DropForeignKey("dbo.Graph", "Account_ID", "dbo.Account");
            DropForeignKey("dbo.Subject", "Account_ID", "dbo.Account");
            DropForeignKey("dbo.TermMention", "Theme_ID", "dbo.Subject");
            DropForeignKey("dbo.Story", "Theme_ID", "dbo.Subject");
            DropIndex("dbo.UserAlert", new[] { "Alert_AlertID" });
            DropIndex("dbo.UserAlert", new[] { "Account_ID" });
            DropIndex("dbo.DashboardItem", new[] { "Graph_GraphId" });
            DropIndex("dbo.Graph", new[] { "Account_ID" });
            DropIndex("dbo.Alert", new[] { "Subject_ID2" });
            DropIndex("dbo.Alert", new[] { "Subject_ID1" });
            DropIndex("dbo.Alert", new[] { "SubjectB_ID" });
            DropIndex("dbo.Alert", new[] { "SubjectA_ID" });
            DropIndex("dbo.Alert", new[] { "Subject_ID" });
            DropIndex("dbo.Alert", new[] { "Graph_GraphId" });
            DropIndex("dbo.TermMention", new[] { "Theme_ID" });
            DropIndex("dbo.Story", new[] { "Theme_ID" });
            DropIndex("dbo.Subject", new[] { "Account_ID" });
            DropTable("dbo.UserAlert");
            DropTable("dbo.SiteContent");
            DropTable("dbo.Feed");
            DropTable("dbo.DashboardItem");
            DropTable("dbo.Graph");
            DropTable("dbo.Alert");
            DropTable("dbo.TermMention");
            DropTable("dbo.Story");
            DropTable("dbo.Subject");
            DropTable("dbo.Account");
        }
    }
}
