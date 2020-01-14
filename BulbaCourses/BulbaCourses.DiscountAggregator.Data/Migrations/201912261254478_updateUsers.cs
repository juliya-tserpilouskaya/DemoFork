namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccountDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IdUserProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfileDbs", t => t.IdUserProfile_Id)
                .Index(t => t.IdUserProfile_Id);
            
            CreateTable(
                "dbo.UserProfileDbs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Subscription = c.Boolean(nullable: false),
                        SubscriptionDateStart = c.DateTime(nullable: false),
                        SubscriptionDateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccountDbs", "IdUserProfile_Id", "dbo.UserProfileDbs");
            DropIndex("dbo.UserAccountDbs", new[] { "IdUserProfile_Id" });
            DropTable("dbo.UserProfileDbs");
            DropTable("dbo.UserAccountDbs");
        }
    }
}
