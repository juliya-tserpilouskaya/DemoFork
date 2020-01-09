namespace BulbaCourses.Video.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false),
                        VideoMaterialDb_VideoId = c.String(maxLength: 128),
                        UserCommentsId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Videos", t => t.VideoMaterialDb_VideoId)
                .ForeignKey("dbo.Users", t => t.UserCommentsId)
                .Index(t => t.VideoMaterialDb_VideoId)
                .Index(t => t.UserCommentsId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Login = c.String(),
                        Biography = c.String(maxLength: 510),
                        SubscriptionType = c.Int(nullable: false),
                        SubscriptionStartDate = c.DateTime(),
                        SubscriptionEndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        Raiting = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        UpdateDate = c.DateTime(),
                        Duration = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CourseAuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Users", t => t.CourseAuthorId)
                .Index(t => t.CourseAuthorId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.TagId)
                .Index(t => t.Content, unique: true);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Url = c.String(),
                        Duration = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        NumberOfViews = c.Int(nullable: false),
                        Raiting = c.Double(nullable: false),
                        Order = c.Int(nullable: false),
                        CourseId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.VideoId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionAmount = c.Double(nullable: false),
                        UserDb_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Users", t => t.UserDb_UserId)
                .Index(t => t.UserDb_UserId);
            
            CreateTable(
                "dbo.CourseTag",
                c => new
                    {
                        TagId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TagId, t.CourseId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserCommentsId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "UserDb_UserId", "dbo.Users");
            DropForeignKey("dbo.Videos", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Comments", "VideoMaterialDb_VideoId", "dbo.Videos");
            DropForeignKey("dbo.CourseTag", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Courses", "CourseAuthorId", "dbo.Users");
            DropIndex("dbo.CourseTag", new[] { "CourseId" });
            DropIndex("dbo.CourseTag", new[] { "TagId" });
            DropIndex("dbo.Transactions", new[] { "UserDb_UserId" });
            DropIndex("dbo.Videos", new[] { "CourseId" });
            DropIndex("dbo.Tags", new[] { "Content" });
            DropIndex("dbo.Courses", new[] { "CourseAuthorId" });
            DropIndex("dbo.Comments", new[] { "UserCommentsId" });
            DropIndex("dbo.Comments", new[] { "VideoMaterialDb_VideoId" });
            DropTable("dbo.CourseTag");
            DropTable("dbo.Transactions");
            DropTable("dbo.Videos");
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
