namespace BulbaCourses.PracticalMaterialsTasks.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TaskDbs", newName: "Tasks");
            RenameTable(name: "dbo.UserDbs", newName: "Users");
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tasks", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "TaskLevel", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "NickName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "NickName", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Tasks", "Created", c => c.DateTime());
            AlterColumn("dbo.Tasks", "TaskLevel", c => c.String());
            AlterColumn("dbo.Tasks", "Text", c => c.String());
            AlterColumn("dbo.Tasks", "Name", c => c.String());
            RenameTable(name: "dbo.Users", newName: "UserDbs");
            RenameTable(name: "dbo.Tasks", newName: "TaskDbs");
        }
    }
}
