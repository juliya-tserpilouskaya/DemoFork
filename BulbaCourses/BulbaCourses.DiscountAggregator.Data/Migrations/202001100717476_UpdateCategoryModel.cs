namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseCategoryDbs", "Domain_Id", "dbo.DomainDbs");
            DropIndex("dbo.CourseCategoryDbs", new[] { "Domain_Id" });
            DropColumn("dbo.CourseCategoryDbs", "Domain_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseCategoryDbs", "Domain_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CourseCategoryDbs", "Domain_Id");
            AddForeignKey("dbo.CourseCategoryDbs", "Domain_Id", "dbo.DomainDbs", "Id");
        }
    }
}
