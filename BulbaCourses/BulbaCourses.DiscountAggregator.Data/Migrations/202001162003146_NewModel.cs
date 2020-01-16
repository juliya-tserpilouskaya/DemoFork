namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseCategories", "Domain_Id", "dbo.Domains");
            DropIndex("dbo.CourseCategories", new[] { "Domain_Id" });
            DropColumn("dbo.CourseCategories", "Domain_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseCategories", "Domain_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CourseCategories", "Domain_Id");
            AddForeignKey("dbo.CourseCategories", "Domain_Id", "dbo.Domains", "Id");
        }
    }
}
