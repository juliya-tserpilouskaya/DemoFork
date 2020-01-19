namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookmarkUserIdIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.bookmark", "user_id", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.bookmark", "user_id", c => c.String());
        }
    }
}
