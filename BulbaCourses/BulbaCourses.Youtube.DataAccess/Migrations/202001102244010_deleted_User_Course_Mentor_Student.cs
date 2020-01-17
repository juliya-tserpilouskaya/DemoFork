namespace BulbaCourses.Youtube.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted_User_Course_Mentor_Student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChannelDbs", "Mentor_Id", "dbo.UserDbs");
            DropForeignKey("dbo.SearchStories", "User_Id", "dbo.UserDbs");
            DropIndex("dbo.ChannelDbs", new[] { "Mentor_Id" });
            DropIndex("dbo.SearchStories", new[] { "User_Id" });
            AddColumn("dbo.SearchStories", "UserId", c => c.String());
            DropColumn("dbo.ChannelDbs", "Mentor_Id");
            DropColumn("dbo.SearchStories", "User_Id");
            DropTable("dbo.UserDbs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 100),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SearchStories", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ChannelDbs", "Mentor_Id", c => c.Int());
            DropColumn("dbo.SearchStories", "UserId");
            CreateIndex("dbo.SearchStories", "User_Id");
            CreateIndex("dbo.ChannelDbs", "Mentor_Id");
            AddForeignKey("dbo.SearchStories", "User_Id", "dbo.UserDbs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChannelDbs", "Mentor_Id", "dbo.UserDbs", "Id");
        }
    }
}
