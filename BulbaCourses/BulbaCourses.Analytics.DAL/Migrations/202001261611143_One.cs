namespace BulbaCourses.Analytics.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class One : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 127),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dashboards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        ChartId = c.Int(nullable: false),
                        ReportId = c.String(nullable: false, maxLength: 128),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        Creator = c.String(maxLength: 255),
                        Modifier = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 255),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        Creator = c.String(maxLength: 128),
                        Modifier = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        KursDollarValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dashboards", "ReportId", "dbo.Reports");
            DropIndex("dbo.Dashboards", new[] { "ReportId" });
            DropTable("dbo.ExchangeRates");
            DropTable("dbo.Reports");
            DropTable("dbo.Dashboards");
            DropTable("dbo.Charts");
        }
    }
}
