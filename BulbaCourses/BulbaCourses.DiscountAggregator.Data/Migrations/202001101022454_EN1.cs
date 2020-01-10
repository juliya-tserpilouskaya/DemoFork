namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EN1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DomainDbs", newName: "Domains");
            AlterColumn("dbo.Domains", "DomainName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Domains", "DomainURL", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Domains", "DomainURL", c => c.String());
            AlterColumn("dbo.Domains", "DomainName", c => c.String());
            RenameTable(name: "dbo.Domains", newName: "DomainDbs");
        }
    }
}
