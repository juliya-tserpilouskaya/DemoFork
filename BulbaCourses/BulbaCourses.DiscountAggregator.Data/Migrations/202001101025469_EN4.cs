namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EN4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseCategoryDbs", newName: "CourseCategorys");
            AlterColumn("dbo.CourseCategorys", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CourseCategorys", "Title", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseCategorys", "Title", c => c.String());
            AlterColumn("dbo.CourseCategorys", "Name", c => c.String());
            RenameTable(name: "dbo.CourseCategorys", newName: "CourseCategoryDbs");
        }
    }
}
