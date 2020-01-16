namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReferensCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseCategories", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropIndex("dbo.CourseCategories", new[] { "SearchCriteriaDb_Id" });
            CreateTable(
                "dbo.SearchCriteriaDbCourseCategoryDbs",
                c => new
                    {
                        SearchCriteriaDb_Id = c.String(nullable: false, maxLength: 128),
                        CourseCategoryDb_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SearchCriteriaDb_Id, t.CourseCategoryDb_Id })
                .ForeignKey("dbo.SearchCriterias", t => t.SearchCriteriaDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategoryDb_Id, cascadeDelete: true)
                .Index(t => t.SearchCriteriaDb_Id)
                .Index(t => t.CourseCategoryDb_Id);
            
            DropColumn("dbo.CourseCategories", "SearchCriteriaDb_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseCategories", "SearchCriteriaDb_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.SearchCriteriaDbCourseCategoryDbs", "CourseCategoryDb_Id", "dbo.CourseCategories");
            DropForeignKey("dbo.SearchCriteriaDbCourseCategoryDbs", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropIndex("dbo.SearchCriteriaDbCourseCategoryDbs", new[] { "CourseCategoryDb_Id" });
            DropIndex("dbo.SearchCriteriaDbCourseCategoryDbs", new[] { "SearchCriteriaDb_Id" });
            DropTable("dbo.SearchCriteriaDbCourseCategoryDbs");
            CreateIndex("dbo.CourseCategories", "SearchCriteriaDb_Id");
            AddForeignKey("dbo.CourseCategories", "SearchCriteriaDb_Id", "dbo.SearchCriterias", "Id");
        }
    }
}
