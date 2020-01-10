namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewM : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false, maxLength: 105));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false, maxLength: 54));
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false, maxLength: 54));
        }
    }
}
