namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseBookmarkDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfileDbs", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.SearchCriteriaDbs",
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
                "dbo.CourseCategoryDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Title = c.String(),
                        Domain_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DomainDbs", t => t.Domain_Id)
                .Index(t => t.Domain_Id);
            
            CreateTable(
                "dbo.DomainDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DomainName = c.String(),
                        DomainURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserProfileDbs", "SearchCriteria_Id");
            AddForeignKey("dbo.UserProfileDbs", "SearchCriteria_Id", "dbo.SearchCriteriaDbs", "Id");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_UserId");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MinPrice");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MaxPrice");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MinDiscount");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MaxDiscount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MaxDiscount", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MinDiscount", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MaxPrice", c => c.Double(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MinPrice", c => c.Double(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_UserId", c => c.String());
            DropForeignKey("dbo.CourseCategoryDbs", "Domain_Id", "dbo.DomainDbs");
            DropForeignKey("dbo.CourseBookmarkDbs", "UserProfile_Id", "dbo.UserProfileDbs");
            DropForeignKey("dbo.UserProfileDbs", "SearchCriteria_Id", "dbo.SearchCriteriaDbs");
            DropIndex("dbo.CourseCategoryDbs", new[] { "Domain_Id" });
            DropIndex("dbo.UserProfileDbs", new[] { "SearchCriteria_Id" });
            DropIndex("dbo.CourseBookmarkDbs", new[] { "UserProfile_Id" });
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_Id");
            DropTable("dbo.DomainDbs");
            DropTable("dbo.CourseCategoryDbs");
            DropTable("dbo.SearchCriteriaDbs");
            DropTable("dbo.CourseBookmarkDbs");
        }
    }
}
