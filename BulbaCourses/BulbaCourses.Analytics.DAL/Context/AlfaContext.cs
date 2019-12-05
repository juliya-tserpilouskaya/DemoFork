using BulbaCourses.Analytics.DAL.Context.Configurations;
using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity;

namespace BulbaCourses.Analytics.DAL.Context
{
    public class AlfaContext : DbContext
    {
        public AlfaContext() : base("AnalyticsDbConnection")
        {
            
        }

        public DbSet<ReportDb> Reports { get; set; }

        public DbSet<DashboardDb> Dashboards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ReportConfigurations());
            modelBuilder.Configurations.Add(new DashboardConfigurations());
        }
    }
}
