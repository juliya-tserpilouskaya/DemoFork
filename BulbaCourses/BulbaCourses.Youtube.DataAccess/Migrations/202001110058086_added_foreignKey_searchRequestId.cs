namespace BulbaCourses.Youtube.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_foreignKey_searchRequestId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SearchStories", name: "SearchRequest_Id", newName: "SearchRequestId");
            RenameIndex(table: "dbo.SearchStories", name: "IX_SearchRequest_Id", newName: "IX_SearchRequestId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SearchStories", name: "IX_SearchRequestId", newName: "IX_SearchRequest_Id");
            RenameColumn(table: "dbo.SearchStories", name: "SearchRequestId", newName: "SearchRequest_Id");
        }
    }
}
