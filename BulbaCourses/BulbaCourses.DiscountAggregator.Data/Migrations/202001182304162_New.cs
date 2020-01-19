namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "SearchCriteriaDb_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "CourseCategoryDb_Id", newName: "SearchCriteriaDb_Id");
            RenameColumn(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "__mig_tmp__0", newName: "CourseCategoryDb_Id");
            RenameIndex(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "IX_CourseCategoryDb_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "IX_SearchCriteriaDb_Id", newName: "IX_CourseCategoryDb_Id");
            RenameIndex(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "__mig_tmp__0", newName: "IX_SearchCriteriaDb_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "IX_SearchCriteriaDb_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "IX_CourseCategoryDb_Id", newName: "IX_SearchCriteriaDb_Id");
            RenameIndex(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "__mig_tmp__0", newName: "IX_CourseCategoryDb_Id");
            RenameColumn(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "CourseCategoryDb_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "SearchCriteriaDb_Id", newName: "CourseCategoryDb_Id");
            RenameColumn(table: "dbo.SearchCriteriaDbCourseCategoryDbs", name: "__mig_tmp__0", newName: "SearchCriteriaDb_Id");
        }
    }
}
