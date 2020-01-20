namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserAccountDbs", name: "IdUserProfile_Id", newName: "UserProfile_Id");
            RenameIndex(table: "dbo.UserAccountDbs", name: "IX_IdUserProfile_Id", newName: "IX_UserProfile_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserAccountDbs", name: "IX_UserProfile_Id", newName: "IX_IdUserProfile_Id");
            RenameColumn(table: "dbo.UserAccountDbs", name: "UserProfile_Id", newName: "IdUserProfile_Id");
        }
    }
}
