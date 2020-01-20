namespace BulbaCourses.Podcasts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Duration = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Course_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Raiting = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Duration = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UserDb_Id = c.String(maxLength: 128),
                        CourseAuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserDb_Id)
                .ForeignKey("dbo.Users", t => t.CourseAuthorId)
                .Index(t => t.Name, unique: true)
                .Index(t => t.UserDb_Id)
                .Index(t => t.CourseAuthorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(maxLength: 510),
                        Email = c.String(),
                        Avatar = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(nullable: false, maxLength: 255),
                        PostDate = c.DateTime(nullable: false),
                        Course_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CourseAuthorId", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "UserDb_Id", "dbo.Users");
            DropForeignKey("dbo.Audios", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Course_Id" });
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.Courses", new[] { "CourseAuthorId" });
            DropIndex("dbo.Courses", new[] { "UserDb_Id" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropIndex("dbo.Audios", new[] { "Course_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
            DropTable("dbo.Audios");
        }
    }
}
