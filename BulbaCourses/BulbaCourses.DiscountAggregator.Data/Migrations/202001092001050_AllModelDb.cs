namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModelDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_UserId", c => c.String());
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MinPrice", c => c.Double(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MaxPrice", c => c.Double(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MinDiscount", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfileDbs", "SearchCriteria_MaxDiscount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MaxDiscount");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MinDiscount");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MaxPrice");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_MinPrice");
            DropColumn("dbo.UserProfileDbs", "SearchCriteria_UserId");
        }
    }
}
