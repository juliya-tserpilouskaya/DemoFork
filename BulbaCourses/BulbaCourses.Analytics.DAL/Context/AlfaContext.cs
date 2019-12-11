using BulbaCourses.Analytics.DAL.Context.Configurations;
using BulbaCourses.Analytics.DAL.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace BulbaCourses.Analytics.DAL.Context
{
    public class AlfaContext : DbContext
    {
        public AlfaContext() : base("AnalyticsDbConnection")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<ReportDb> Reports { get; set; }

        public DbSet<DashboardDb> Dashboards { get; set; }

        public DbSet<ChartDb> Charts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           

            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<AlfaContext>());

            modelBuilder.Configurations.Add(new ReportConfigurations());
            modelBuilder.Configurations.Add(new DashboardConfigurations());
            modelBuilder.Configurations.Add(new ChartConfigurations());

            Debug.WriteLine("+++++++++++++ OnModelCreating +++++++++++++");
        }
    }
}
