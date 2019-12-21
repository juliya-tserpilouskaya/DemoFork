using BulbaCourses.Analytics.DAL.Context.Configurations;
using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace BulbaCourses.Analytics.DAL.Context
{  
    [DbConfigurationType(typeof(DbConfig))]
    public class AnalyticsContext : DbContext
    {
        public AnalyticsContext() : base("AnalyticsDbConnection")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<ReportDb> Reports { get; set; }

        public DbSet<DashboardDb> Dashboards { get; set; }

        public DbSet<ChartDb> Charts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Uncomment if need create Database
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AnalyticsContext>());

            modelBuilder.Configurations.Add(new ReportConfigurations());
            modelBuilder.Configurations.Add(new DashboardConfigurations());
            modelBuilder.Configurations.Add(new ChartConfigurations());

            Debug.WriteLine("+++++++++++++ AnalyticsContext OnModelCreating +++++++++++++");
        }
    }
}
