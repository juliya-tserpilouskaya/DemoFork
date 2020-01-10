namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUserAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAccounts", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserAccounts", new[] { "UserProfile_Id" });
            AddColumn("dbo.UserProfiles", "Email", c => c.String(nullable: false, maxLength: 105));
            DropTable("dbo.UserAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Login = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false, maxLength: 105),
                        UserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.UserProfiles", "Email");
            CreateIndex("dbo.UserAccounts", "UserProfile_Id");
            AddForeignKey("dbo.UserAccounts", "UserProfile_Id", "dbo.UserProfiles", "Id");
        }
    }
}
