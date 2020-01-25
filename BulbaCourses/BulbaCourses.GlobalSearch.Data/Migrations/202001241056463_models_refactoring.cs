namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models_refactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.bookmark", "UserDB_Id", "dbo.user");
            DropForeignKey("dbo.search_query", "UserDB_Id", "dbo.user");
            DropIndex("dbo.bookmark", new[] { "UserDB_Id" });
            DropIndex("dbo.search_query", new[] { "UserDB_Id" });
            AddColumn("dbo.bookmark", "catedory", c => c.String());
            DropColumn("dbo.bookmark", "UserDB_Id");
            DropColumn("dbo.search_query", "UserDB_Id");
            DropTable("dbo.user");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        authorization = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.search_query", "UserDB_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.bookmark", "UserDB_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.bookmark", "catedory");
            CreateIndex("dbo.search_query", "UserDB_Id");
            CreateIndex("dbo.bookmark", "UserDB_Id");
            AddForeignKey("dbo.search_query", "UserDB_Id", "dbo.user", "id");
            AddForeignKey("dbo.bookmark", "UserDB_Id", "dbo.user", "id");
        }
    }
}
