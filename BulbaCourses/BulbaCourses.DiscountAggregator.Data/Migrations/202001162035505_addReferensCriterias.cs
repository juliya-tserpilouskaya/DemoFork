namespace BulbaCourses.DiscountAggregator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReferensCriterias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Domains", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropIndex("dbo.Domains", new[] { "SearchCriteriaDb_Id" });
            CreateTable(
                "dbo.SearchCriteriaDbDomainDbs",
                c => new
                    {
                        SearchCriteriaDb_Id = c.String(nullable: false, maxLength: 128),
                        DomainDb_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SearchCriteriaDb_Id, t.DomainDb_Id })
                .ForeignKey("dbo.SearchCriterias", t => t.SearchCriteriaDb_Id, cascadeDelete: true)
                .ForeignKey("dbo.Domains", t => t.DomainDb_Id, cascadeDelete: true)
                .Index(t => t.SearchCriteriaDb_Id)
                .Index(t => t.DomainDb_Id);
            
            DropColumn("dbo.Domains", "SearchCriteriaDb_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Domains", "SearchCriteriaDb_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.SearchCriteriaDbDomainDbs", "DomainDb_Id", "dbo.Domains");
            DropForeignKey("dbo.SearchCriteriaDbDomainDbs", "SearchCriteriaDb_Id", "dbo.SearchCriterias");
            DropIndex("dbo.SearchCriteriaDbDomainDbs", new[] { "DomainDb_Id" });
            DropIndex("dbo.SearchCriteriaDbDomainDbs", new[] { "SearchCriteriaDb_Id" });
            DropTable("dbo.SearchCriteriaDbDomainDbs");
            CreateIndex("dbo.Domains", "SearchCriteriaDb_Id");
            AddForeignKey("dbo.Domains", "SearchCriteriaDb_Id", "dbo.SearchCriterias", "Id");
        }
    }
}
