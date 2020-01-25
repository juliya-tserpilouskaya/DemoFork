namespace BulbaCourses.TextMaterials_Presentations.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Update = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Presentations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 255),
                        IsAccessible = c.Boolean(nullable: false),
                        TeacherDBId = c.String(maxLength: 128),
                        CourseDBId = c.String(maxLength: 128),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseDBId)
                .ForeignKey("dbo.Teachers", t => t.TeacherDBId)
                .Index(t => t.Title, unique: true)
                .Index(t => t.TeacherDBId)
                .Index(t => t.CourseDBId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Text = c.String(nullable: false, maxLength: 255),
                        StudentDBId = c.String(maxLength: 128),
                        TeacherDBId = c.String(maxLength: 128),
                        PresentationDBId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Presentations", t => t.PresentationDBId)
                .ForeignKey("dbo.Students", t => t.StudentDBId)
                .ForeignKey("dbo.Teachers", t => t.TeacherDBId)
                .Index(t => t.StudentDBId)
                .Index(t => t.TeacherDBId)
                .Index(t => t.PresentationDBId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PhoneNumber = c.String(nullable: false, maxLength: 25),
                        Position = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        PresentationDB_Id = c.String(nullable: false, maxLength: 128),
                        StudentDB_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PresentationDB_Id, t.StudentDB_Id })
                .ForeignKey("dbo.Presentations", t => t.PresentationDB_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentDB_Id, cascadeDelete: true)
                .Index(t => t.PresentationDB_Id)
                .Index(t => t.StudentDB_Id);
            
            CreateTable(
                "dbo.Viewed",
                c => new
                    {
                        PresentationDB_Id = c.String(nullable: false, maxLength: 128),
                        StudentDB_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PresentationDB_Id, t.StudentDB_Id })
                .ForeignKey("dbo.Presentations", t => t.PresentationDB_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentDB_Id, cascadeDelete: true)
                .Index(t => t.PresentationDB_Id)
                .Index(t => t.StudentDB_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewed", "StudentDB_Id", "dbo.Students");
            DropForeignKey("dbo.Viewed", "PresentationDB_Id", "dbo.Presentations");
            DropForeignKey("dbo.Presentations", "TeacherDBId", "dbo.Teachers");
            DropForeignKey("dbo.Favorite", "StudentDB_Id", "dbo.Students");
            DropForeignKey("dbo.Favorite", "PresentationDB_Id", "dbo.Presentations");
            DropForeignKey("dbo.Feedbacks", "TeacherDBId", "dbo.Teachers");
            DropForeignKey("dbo.Feedbacks", "StudentDBId", "dbo.Students");
            DropForeignKey("dbo.Feedbacks", "PresentationDBId", "dbo.Presentations");
            DropForeignKey("dbo.Presentations", "CourseDBId", "dbo.Courses");
            DropIndex("dbo.Viewed", new[] { "StudentDB_Id" });
            DropIndex("dbo.Viewed", new[] { "PresentationDB_Id" });
            DropIndex("dbo.Favorite", new[] { "StudentDB_Id" });
            DropIndex("dbo.Favorite", new[] { "PresentationDB_Id" });
            DropIndex("dbo.Feedbacks", new[] { "PresentationDBId" });
            DropIndex("dbo.Feedbacks", new[] { "TeacherDBId" });
            DropIndex("dbo.Feedbacks", new[] { "StudentDBId" });
            DropIndex("dbo.Presentations", new[] { "CourseDBId" });
            DropIndex("dbo.Presentations", new[] { "TeacherDBId" });
            DropIndex("dbo.Presentations", new[] { "Title" });
            DropIndex("dbo.Courses", new[] { "Name" });
            DropTable("dbo.Viewed");
            DropTable("dbo.Favorite");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Presentations");
            DropTable("dbo.Courses");
        }
    }
}
