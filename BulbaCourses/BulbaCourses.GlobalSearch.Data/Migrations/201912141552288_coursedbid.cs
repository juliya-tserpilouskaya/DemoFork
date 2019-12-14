namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursedbid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.course_item", name: "CourseDB_Id", newName: "CourseDBId");
            RenameIndex(table: "dbo.course_item", name: "IX_CourseDB_Id", newName: "IX_CourseDBId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.course_item", name: "IX_CourseDBId", newName: "IX_CourseDB_Id");
            RenameColumn(table: "dbo.course_item", name: "CourseDBId", newName: "CourseDB_Id");
        }
    }
}
