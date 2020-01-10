namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EN2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseBookmarkDbs", newName: "CourseBookmarks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CourseBookmarks", newName: "CourseBookmarkDbs");
        }
    }
}
