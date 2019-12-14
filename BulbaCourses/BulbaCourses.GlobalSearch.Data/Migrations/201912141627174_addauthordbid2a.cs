namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addauthordbid2a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.course", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.course", "AuthorId", c => c.Int(nullable: false));
        }
    }
}
