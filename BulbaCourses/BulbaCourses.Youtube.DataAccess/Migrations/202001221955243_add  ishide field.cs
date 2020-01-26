namespace BulbaCourses.Youtube.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addishidefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchStories", "IsHideForUser", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SearchStories", "IsHideForUser");
        }
    }
}
