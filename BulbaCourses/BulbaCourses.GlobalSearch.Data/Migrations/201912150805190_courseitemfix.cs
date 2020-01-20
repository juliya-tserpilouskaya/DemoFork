namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseitemfix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.course_item", name: "course_bd_id", newName: "CourseDBId");
            RenameIndex(table: "dbo.course_item", name: "IX_course_bd_id", newName: "IX_CourseDBId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.course_item", name: "IX_CourseDBId", newName: "IX_course_bd_id");
            RenameColumn(table: "dbo.course_item", name: "CourseDBId", newName: "course_bd_id");
        }
    }
}
