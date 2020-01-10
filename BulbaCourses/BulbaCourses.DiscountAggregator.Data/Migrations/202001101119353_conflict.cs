namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conflict : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseCategorys", newName: "CourseCategories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CourseCategories", newName: "CourseCategorys");
        }
    }
}
