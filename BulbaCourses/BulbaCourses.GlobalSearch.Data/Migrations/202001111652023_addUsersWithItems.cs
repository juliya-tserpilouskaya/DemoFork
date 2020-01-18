namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsersWithItems : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.bookmark", name: "UserId", newName: "user_id");
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        authorization = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);

            AddColumn("dbo.bookmark", "UserDB_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.search_query", "user_id", c => c.String());
            AddColumn("dbo.search_query", "UserDB_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.bookmark", "UserDB_Id");
            CreateIndex("dbo.search_query", "UserDB_Id");
            AddForeignKey("dbo.bookmark", "UserDB_Id", "dbo.user", "id");
            AddForeignKey("dbo.search_query", "UserDB_Id", "dbo.user", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.search_query", "UserDB_Id", "dbo.user");
            DropForeignKey("dbo.bookmark", "UserDB_Id", "dbo.user");
            DropIndex("dbo.search_query", new[] { "UserDB_Id" });
            DropIndex("dbo.bookmark", new[] { "UserDB_Id" });
            DropColumn("dbo.search_query", "UserDB_Id");
            DropColumn("dbo.search_query", "user_id");
            DropColumn("dbo.bookmark", "UserDB_Id");
            DropTable("dbo.user");
            RenameColumn(table: "dbo.bookmark", name: "user_id", newName: "UserId");
        }
    }
}
