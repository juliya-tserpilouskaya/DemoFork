namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addauthordbid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.course", "AuthorDBId", c => c.Int(nullable: false));
            CreateIndex("dbo.course", "AuthorDBId");
            AddForeignKey("dbo.course", "AuthorDBId", "dbo.author", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.course", "AuthorDBId", "dbo.author");
            DropIndex("dbo.course", new[] { "AuthorDBId" });
            DropColumn("dbo.course", "AuthorDBId");
        }
    }
}
