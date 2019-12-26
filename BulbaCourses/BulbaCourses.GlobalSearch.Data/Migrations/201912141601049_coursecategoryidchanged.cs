namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursecategoryidchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.course", "CourseCategoryDB_Id", "dbo.course_category");
            DropIndex("dbo.course", new[] { "CourseCategoryDB_Id" });
            RenameColumn(table: "dbo.course", name: "CourseCategoryDB_Id", newName: "CourseCategoryDBId");
            AlterColumn("dbo.course", "CourseCategoryDBId", c => c.Int(nullable: false));
            CreateIndex("dbo.course", "CourseCategoryDBId");
            AddForeignKey("dbo.course", "CourseCategoryDBId", "dbo.course_category", "id", cascadeDelete: true);
            DropColumn("dbo.course", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.course", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.course", "CourseCategoryDBId", "dbo.course_category");
            DropIndex("dbo.course", new[] { "CourseCategoryDBId" });
            AlterColumn("dbo.course", "CourseCategoryDBId", c => c.Int());
            RenameColumn(table: "dbo.course", name: "CourseCategoryDBId", newName: "CourseCategoryDB_Id");
            CreateIndex("dbo.course", "CourseCategoryDB_Id");
            AddForeignKey("dbo.course", "CourseCategoryDB_Id", "dbo.course_category", "id");
        }
    }
}
