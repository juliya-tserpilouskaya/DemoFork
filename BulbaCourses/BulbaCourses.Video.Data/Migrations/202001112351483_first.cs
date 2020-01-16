namespace BulbaCourses.Video.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Annotation = c.String(nullable: false, maxLength: 1024),
                        Professions = c.String(nullable: false),
                        User_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AuthorId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        Raiting = c.Double(nullable: false),
                        RateCount = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1024),
                        Date = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        Duration = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CourseAuthorId = c.String(maxLength: 128),
                        UserDb_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Authors", t => t.CourseAuthorId)
                .ForeignKey("dbo.Users", t => t.UserDb_UserId)
                .Index(t => t.CourseAuthorId)
                .Index(t => t.UserDb_UserId);
            
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
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false),
                        UserCommentsId = c.String(maxLength: 128),
                        VideoId_VideoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserCommentsId)
                .ForeignKey("dbo.Videos", t => t.VideoId_VideoId)
                .Index(t => t.UserCommentsId)
                .Index(t => t.VideoId_VideoId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Login = c.String(),
                        SubscriptionType = c.Int(nullable: false),
                        SubscriptionStartDate = c.DateTime(),
                        SubscriptionEndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.String(nullable: false, maxLength: 128),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionAmount = c.Double(nullable: false),
                        User_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
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
            DropForeignKey("dbo.Authors", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Videos", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Comments", "VideoId_VideoId", "dbo.Videos");
            DropForeignKey("dbo.Comments", "UserCommentsId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Courses", "UserDb_UserId", "dbo.Users");
            DropForeignKey("dbo.CourseTag", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Courses", "CourseAuthorId", "dbo.Authors");
            DropIndex("dbo.CourseTag", new[] { "CourseId" });
            DropIndex("dbo.CourseTag", new[] { "TagId" });
            DropIndex("dbo.Transactions", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "VideoId_VideoId" });
            DropIndex("dbo.Comments", new[] { "UserCommentsId" });
            DropIndex("dbo.Videos", new[] { "CourseId" });
            DropIndex("dbo.Tags", new[] { "Content" });
            DropIndex("dbo.Courses", new[] { "UserDb_UserId" });
            DropIndex("dbo.Courses", new[] { "CourseAuthorId" });
            DropIndex("dbo.Authors", new[] { "User_UserId" });
            DropTable("dbo.CourseTag");
            DropTable("dbo.Transactions");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Videos");
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
