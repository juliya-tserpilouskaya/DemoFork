namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ignorechange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseBookmarkDbs", newName: "CourseBookmarks");
            RenameTable(name: "dbo.UserProfileDbs", newName: "UserProfiles");
            RenameTable(name: "dbo.SearchCriteriaDbs", newName: "SearchCriterias");
            RenameTable(name: "dbo.CourseCategoryDbs", newName: "CourseCategories");
            RenameTable(name: "dbo.DomainDbs", newName: "Domains");
            RenameTable(name: "dbo.UserAccountDbs", newName: "UserAccounts");
            AddColumn("dbo.CourseCategories", "SearchCriteriaDb_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Domains", "SearchCriteriaDb_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "CourseBookmarkDb_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CourseCategories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CourseCategories", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Domains", "DomainName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Domains", "DomainURL", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Courses", "URL", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.UserAccounts", "Login", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false, maxLength: 105));
            CreateIndex("dbo.Courses", "CourseBookmarkDb_Id");
            CreateIndex("dbo.CourseCategories", "SearchCriteriaDb_Id");
            CreateIndex("dbo.Domains", "SearchCriteriaDb_Id");
            AddForeignKey("dbo.Courses", "CourseBookmarkDb_Id", "dbo.CourseBookmarks", "Id");
            AddForeignKey("dbo.CourseCategories", "SearchCriteriaDb_Id", "dbo.SearchCriterias", "Id");
            AddForeignKey("dbo.Domains", "SearchCriteriaDb_Id", "dbo.SearchCriterias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Domains", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropForeignKey("dbo.CourseCategories", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropForeignKey("dbo.Courses", "CourseBookmarkDb_Id", "dbo.CourseBookmarks");
            DropIndex("dbo.Domains", new[] { "SearchCriteriaDb_Id" });
            DropIndex("dbo.CourseCategories", new[] { "SearchCriteriaDb_Id" });
            DropIndex("dbo.Courses", new[] { "CourseBookmarkDb_Id" });
            AlterColumn("dbo.UserAccounts", "Email", c => c.String());
            AlterColumn("dbo.UserAccounts", "Password", c => c.String());
            AlterColumn("dbo.UserAccounts", "Login", c => c.String());
            AlterColumn("dbo.Courses", "URL", c => c.String());
            AlterColumn("dbo.Domains", "DomainURL", c => c.String());
            AlterColumn("dbo.Domains", "DomainName", c => c.String());
            AlterColumn("dbo.CourseCategories", "Title", c => c.String());
            AlterColumn("dbo.CourseCategories", "Name", c => c.String());
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String());
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String());
            DropColumn("dbo.Courses", "CourseBookmarkDb_Id");
            DropColumn("dbo.Domains", "SearchCriteriaDb_Id");
            DropColumn("dbo.CourseCategories", "SearchCriteriaDb_Id");
            RenameTable(name: "dbo.UserAccounts", newName: "UserAccountDbs");
            RenameTable(name: "dbo.Domains", newName: "DomainDbs");
            RenameTable(name: "dbo.CourseCategories", newName: "CourseCategoryDbs");
            RenameTable(name: "dbo.SearchCriterias", newName: "SearchCriteriaDbs");
            RenameTable(name: "dbo.UserProfiles", newName: "UserProfileDbs");
            RenameTable(name: "dbo.CourseBookmarks", newName: "CourseBookmarkDbs");
        }
    }
}
