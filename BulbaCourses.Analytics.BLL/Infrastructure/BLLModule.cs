using BulbaCourses.Analytics.BLL.Interfaces;
using BulbaCourses.Analytics.BLL.Services;
using BulbaCourses.Analytics.DAL.Entities.Coupling;
using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using BulbaCourses.Analytics.DAL.Entities.Reports;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.DAL.Repositories;
using BulbaCourses.Analytics.DAL.Storage;
using Ninject.Modules;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IReportStorage>().To<ReportStorage>();
            Bind<IRepository<Report>>().To<ReportRepository>();

            Bind<IDashboardStorage>().To<DashboardStorage>();
            Bind<IRepository<Dashboard>>().To<DashboardRepository>();

            Bind<ILinksStorage>().To<LinksStorage>();
            Bind<IRepository<Links>>().To<LinksRepository>();

            Bind<IDataBase>().To<DataBase>();
            Bind<IDashboardService>().To<DashboardService>();

            //Bind<ReportService>().ToSelf();
            //Bind<IReportService>().To<ReportService>();

        }
    }
}
