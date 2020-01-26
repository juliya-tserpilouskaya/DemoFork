namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookmark_model_changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.bookmark", "description", c => c.String());
            DropColumn("dbo.bookmark", "catedory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.bookmark", "catedory", c => c.String());
            DropColumn("dbo.bookmark", "description");
        }
    }
}
