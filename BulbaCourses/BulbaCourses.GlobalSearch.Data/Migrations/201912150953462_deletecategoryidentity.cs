namespace BulbaCourses.GlobalSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecategoryidentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.course", "course_category_id", "dbo.course_category");
            DropPrimaryKey("dbo.course_category");
            AlterColumn("dbo.course_category", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.course_category", "id");
            AddForeignKey("dbo.course", "course_category_id", "dbo.course_category", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.course", "course_category_id", "dbo.course_category");
            DropPrimaryKey("dbo.course_category");
            AlterColumn("dbo.course_category", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.course_category", "id");
            AddForeignKey("dbo.course", "course_category_id", "dbo.course_category", "id", cascadeDelete: true);
        }
    }
}
