namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbookmark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bookmark",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        title = c.String(maxLength: 255),
                        url = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.bookmark");
        }
    }
}
