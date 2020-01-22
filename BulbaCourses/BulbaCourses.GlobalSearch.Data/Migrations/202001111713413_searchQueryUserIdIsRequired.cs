namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class searchQueryUserIdIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.search_query", "user_id", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.search_query", "user_id", c => c.String());
        }
    }
}
