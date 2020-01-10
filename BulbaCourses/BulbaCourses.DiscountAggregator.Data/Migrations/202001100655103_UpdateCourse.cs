namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Category_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "Domain_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "Category_Id");
            CreateIndex("dbo.Courses", "Domain_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.CourseCategoryDbs", "Id");
            AddForeignKey("dbo.Courses", "Domain_Id", "dbo.DomainDbs", "Id");
            DropColumn("dbo.Courses", "Domain");
            DropColumn("dbo.Courses", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Category", c => c.String());
            AddColumn("dbo.Courses", "Domain", c => c.String());
            DropForeignKey("dbo.Courses", "Domain_Id", "dbo.DomainDbs");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.CourseCategoryDbs");
            DropIndex("dbo.Courses", new[] { "Domain_Id" });
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropColumn("dbo.Courses", "Domain_Id");
            DropColumn("dbo.Courses", "Category_Id");
        }
    }
}
