namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseBookmarks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        URL = c.String(nullable: false, maxLength: 500),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        OldPrice = c.Double(nullable: false),
                        DateOldPrice = c.DateTime(),
                        Discount = c.Int(nullable: false),
                        DateStartCourse = c.DateTime(),
                        DateChange = c.DateTime(),
                        Category_Id = c.String(maxLength: 128),
                        Domain_Id = c.String(maxLength: 128),
                        CourseBookmarkDb_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCategories", t => t.Category_Id)
                .ForeignKey("dbo.Domains", t => t.Domain_Id)
                .ForeignKey("dbo.CourseBookmarks", t => t.CourseBookmarkDb_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Domain_Id)
                .Index(t => t.CourseBookmarkDb_Id);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchCriterias",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MinPrice = c.Double(nullable: false),
                        MaxPrice = c.Double(nullable: false),
                        MinDiscount = c.Int(nullable: false),
                        MaxDiscount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DomainName = c.String(nullable: false, maxLength: 255),
                        DomainURL = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 105),
                        DateOfBirth = c.DateTime(nullable: false),
                        Subscription = c.Boolean(nullable: false),
                        SubscriptionDateStart = c.DateTime(nullable: false),
                        SubscriptionDateEnd = c.DateTime(nullable: false),
                        SearchCriteria_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SearchCriterias", t => t.SearchCriteria_Id)
                .Index(t => t.SearchCriteria_Id);
            
            CreateTable(
                "dbo.SearchCriteriaDbDomainDbs",
                c => new
                    {
                        SearchCriteriaDb_Id = c.String(nullable: false, maxLength: 128),
                        DomainDb_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SearchCriteriaDb_Id, t.DomainDb_Id })
                .ForeignKey("dbo.SearchCriterias", t => t.SearchCriteriaDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.Domains", t => t.DomainDb_Id, cascadeDelete: true)
                .Index(t => t.SearchCriteriaDb_Id)
                .Index(t => t.DomainDb_Id);
            
            CreateTable(
                "dbo.SearchCriteriaDbCourseCategoryDbs",
                c => new
                    {
                        SearchCriteriaDb_Id = c.String(nullable: false, maxLength: 128),
                        CourseCategoryDb_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SearchCriteriaDb_Id, t.CourseCategoryDb_Id })
                .ForeignKey("dbo.CourseCategories", t => t.SearchCriteriaDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.SearchCriterias", t => t.CourseCategoryDb_Id, cascadeDelete: true)
                .Index(t => t.SearchCriteriaDb_Id)
                .Index(t => t.CourseCategoryDb_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseBookmarks", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "SearchCriteria_Id", "dbo.SearchCriterias");
            DropForeignKey("dbo.Courses", "CourseBookmarkDb_Id", "dbo.CourseBookmarks");
            DropForeignKey("dbo.Courses", "Domain_Id", "dbo.Domains");
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.CourseCategories");
            DropForeignKey("dbo.SearchCriteriaDbCourseCategoryDbs", "CourseCategoryDb_Id", "dbo.SearchCriterias");
            DropForeignKey("dbo.SearchCriteriaDbCourseCategoryDbs", "SearchCriteriaDb_Id", "dbo.CourseCategories");
            DropForeignKey("dbo.SearchCriteriaDbDomainDbs", "DomainDb_Id", "dbo.Domains");
            DropForeignKey("dbo.SearchCriteriaDbDomainDbs", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropIndex("dbo.SearchCriteriaDbCourseCategoryDbs", new[] { "CourseCategoryDb_Id" });
            DropIndex("dbo.SearchCriteriaDbCourseCategoryDbs", new[] { "SearchCriteriaDb_Id" });
            DropIndex("dbo.SearchCriteriaDbDomainDbs", new[] { "DomainDb_Id" });
            DropIndex("dbo.SearchCriteriaDbDomainDbs", new[] { "SearchCriteriaDb_Id" });
            DropIndex("dbo.UserProfiles", new[] { "SearchCriteria_Id" });
            DropIndex("dbo.Courses", new[] { "CourseBookmarkDb_Id" });
            DropIndex("dbo.Courses", new[] { "Domain_Id" });
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropIndex("dbo.CourseBookmarks", new[] { "UserProfile_Id" });
            DropTable("dbo.SearchCriteriaDbCourseCategoryDbs");
            DropTable("dbo.SearchCriteriaDbDomainDbs");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Domains");
            DropTable("dbo.SearchCriterias");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseBookmarks");
        }
    }
}
