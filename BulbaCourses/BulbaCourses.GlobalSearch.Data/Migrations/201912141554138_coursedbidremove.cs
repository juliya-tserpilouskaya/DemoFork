namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coursedbidremove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.course_item", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.course_item", "CourseId", c => c.String());
        }
    }
}
