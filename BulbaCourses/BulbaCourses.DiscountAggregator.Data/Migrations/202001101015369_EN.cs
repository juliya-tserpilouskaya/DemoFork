namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EN : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseDbs", newName: "Courses");
            RenameTable(name: "dbo.SearchCriteriaDbs", newName: "SearchCriterias");
            AlterColumn("dbo.Courses", "URL", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Title", c => c.String());
            AlterColumn("dbo.Courses", "URL", c => c.String());
            RenameTable(name: "dbo.SearchCriterias", newName: "SearchCriteriaDbs");
            RenameTable(name: "dbo.Courses", newName: "CourseDbs");
        }
    }
}
