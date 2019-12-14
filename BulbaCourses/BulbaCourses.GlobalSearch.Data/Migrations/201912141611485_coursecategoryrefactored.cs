namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursecategoryrefactored : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.course", name: "CourseCategoryDBId", newName: "course_category_id");
            RenameIndex(table: "dbo.course", name: "IX_CourseCategoryDBId", newName: "IX_course_category_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.course", name: "IX_course_category_id", newName: "IX_CourseCategoryDBId");
            RenameColumn(table: "dbo.course", name: "course_category_id", newName: "CourseCategoryDBId");
        }
    }
}
