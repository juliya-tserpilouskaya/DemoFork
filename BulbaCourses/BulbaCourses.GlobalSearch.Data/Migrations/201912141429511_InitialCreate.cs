namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.author",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.course_category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.course",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false, maxLength: 255),
                        CategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        cost = c.Double(nullable: false),
                        complexity = c.String(),
                        Language = c.String(),
                        description = c.String(nullable: false, maxLength: 1000),
                        created = c.DateTime(),
                        Modified = c.DateTime(),
                        CourseCategoryDB_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.course_category", t => t.CourseCategoryDB_Id)
                .Index(t => t.CourseCategoryDB_Id);
            
            CreateTable(
                "dbo.course_item",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(),
                        name = c.String(nullable: false, maxLength: 255),
                        description = c.String(nullable: false, maxLength: 1000),
                        url = c.String(),
                        CourseDB_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.course", t => t.CourseDB_Id)
                .Index(t => t.CourseDB_Id);
            
            CreateTable(
                "dbo.search_query",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        query_string = c.String(nullable: false),
                        date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.course", "CourseCategoryDB_Id", "dbo.course_category");
            DropForeignKey("dbo.course_item", "CourseDB_Id", "dbo.course");
            DropIndex("dbo.course_item", new[] { "CourseDB_Id" });
            DropIndex("dbo.course", new[] { "CourseCategoryDB_Id" });
            DropTable("dbo.search_query");
            DropTable("dbo.course_item");
            DropTable("dbo.course");
            DropTable("dbo.course_category");
            DropTable("dbo.author");
        }
    }
}
