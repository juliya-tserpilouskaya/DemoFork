using BulbaCourses.Analytics.DAL.Storage;
using BulbaCourses.Analytics.DAL.Entities.Coupling;
using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using BulbaCourses.Analytics.DAL.Entities.Reports;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.DAL.Repositories;
using Ninject.Modules;

namespace BulbaCourses.Analytics.DAL.Infrastructure
{
    public class DALModule : NinjectModule
    {        
        public override void Load()
        {
            Bind<IReportStorage>().To<ReportStorage>();
            Bind<IRepository<Report>>().To<ReportRepository>();

            Bind<IDashboardStorage>().To<DashboardStorage>();
            Bind<IRepository<Dashboard>>().To<DashboardRepository>();

            Bind<ILinksStorage>().To<LinksStorage>();
            Bind<IRepository<Links>>().To<LinksRepository>();
        }
    }
}
