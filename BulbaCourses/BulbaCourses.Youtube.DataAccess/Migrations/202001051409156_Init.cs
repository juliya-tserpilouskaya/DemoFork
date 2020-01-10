namespace BulbaCourses.Youtube.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChannelDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 200),
                        Mentor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDbs", t => t.Mentor_Id)
                .Index(t => t.Mentor_Id);
            
            CreateTable(
                "dbo.UserDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(nullable: false, maxLength: 100),
                        NumberPhone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 200),
                        ReserveEmail = c.String(nullable: false, maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchDate = c.DateTime(nullable: false),
                        SearchRequest_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchRequests", t => t.SearchRequest_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserDbs", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.SearchRequest_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SearchRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CacheId = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        PublishedBefore = c.DateTime(),
                        PublishedAfter = c.DateTime(),
                        Definition = c.String(nullable: false),
                        Dimension = c.String(nullable: false),
                        Duration = c.String(nullable: false),
                        VideoCaption = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResultVideoDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        PublishedAt = c.DateTime(nullable: false),
                        Definition = c.String(nullable: false),
                        Dimension = c.String(nullable: false),
                        Duration = c.String(nullable: false),
                        VideoCaption = c.String(nullable: false),
                        Thumbnail = c.String(nullable: false),
                        Channel_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChannelDbs", t => t.Channel_Id, cascadeDelete: true)
                .Index(t => t.Channel_Id);
            
            CreateTable(
                "dbo.SearchRequestDbResultVideoDbs",
                c => new
                    {
                        SearchRequestDb_Id = c.Int(nullable: false),
                        ResultVideoDb_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SearchRequestDb_Id, t.ResultVideoDb_Id })
                .ForeignKey("dbo.SearchRequests", t => t.SearchRequestDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.ResultVideoDbs", t => t.ResultVideoDb_Id, cascadeDelete: true)
                .Index(t => t.SearchRequestDb_Id)
                .Index(t => t.ResultVideoDb_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultVideoDbs", "Channel_Id", "dbo.ChannelDbs");
            DropForeignKey("dbo.SearchStories", "User_Id", "dbo.UserDbs");
            DropForeignKey("dbo.SearchRequestDbResultVideoDbs", "ResultVideoDb_Id", "dbo.ResultVideoDbs");
            DropForeignKey("dbo.SearchRequestDbResultVideoDbs", "SearchRequestDb_Id", "dbo.SearchRequests");
            DropForeignKey("dbo.SearchStories", "SearchRequest_Id", "dbo.SearchRequests");
            DropForeignKey("dbo.ChannelDbs", "Mentor_Id", "dbo.UserDbs");
            DropIndex("dbo.SearchRequestDbResultVideoDbs", new[] { "ResultVideoDb_Id" });
            DropIndex("dbo.SearchRequestDbResultVideoDbs", new[] { "SearchRequestDb_Id" });
            DropIndex("dbo.ResultVideoDbs", new[] { "Channel_Id" });
            DropIndex("dbo.SearchStories", new[] { "User_Id" });
            DropIndex("dbo.SearchStories", new[] { "SearchRequest_Id" });
            DropIndex("dbo.ChannelDbs", new[] { "Mentor_Id" });
            DropTable("dbo.SearchRequestDbResultVideoDbs");
            DropTable("dbo.ResultVideoDbs");
            DropTable("dbo.SearchRequests");
            DropTable("dbo.SearchStories");
            DropTable("dbo.UserDbs");
            DropTable("dbo.ChannelDbs");
        }
    }
}
