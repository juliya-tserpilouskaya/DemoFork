namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Domain", c => c.String());
            AddColumn("dbo.Courses", "OldPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Courses", "DateOldPrice", c => c.DateTime());
            AddColumn("dbo.Courses", "DateStartCourse", c => c.DateTime());
            AddColumn("dbo.Courses", "DateChange", c => c.DateTime());
            DropColumn("dbo.Courses", "Modified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Modified", c => c.DateTime());
            DropColumn("dbo.Courses", "DateChange");
            DropColumn("dbo.Courses", "DateStartCourse");
            DropColumn("dbo.Courses", "DateOldPrice");
            DropColumn("dbo.Courses", "OldPrice");
            DropColumn("dbo.Courses", "Domain");
        }
    }
}
