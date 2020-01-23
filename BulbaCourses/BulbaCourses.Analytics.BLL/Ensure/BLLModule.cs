using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.BLL.Services;
using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.DAL.Repositories;
using Ninject.Modules;

namespace BulbaCourses.Analytics.BLL.Ensure
{
    /// <summary>
    /// Represents BLL Module.
    /// </summary>
    public class BLLModule : NinjectModule
    {
        /// <summary>
        /// Loads binds.
        /// </summary>
        public override void Load()
        {
            // Bind Reports
            Bind<IReportsService>().To<ReportsService>();
            Bind<IRepository<ReportDb>>().To<ReportsRepository>();

            // Bind Dashboards
            Bind<IDashboardsService>().To<DashboardsService>();
            Bind<IDashboardsRepository>().To<DashboardsRepository>();
        }
    }
}
