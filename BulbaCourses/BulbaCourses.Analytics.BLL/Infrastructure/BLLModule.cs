using BulbaCourses.Analytics.BLL.DTO;
using BulbaCourses.Analytics.BLL.Services;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.DAL.Repositories;
using BulbaCourses.Analytics.DAL.Storage;
using BulbaCourses.Analytics.Infrastructure.BLL.Models;
using BulbaCourses.Analytics.Infrastructure.BLL.Services;
using BulbaCourses.Analytics.Infrastructure.DAL;
using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using Ninject.Modules;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            // Bind BLL
            Bind<IReportDto>().To<ReportDto>();
            Bind<IReportService>().To<ReportService>();

            // Bind DAL
            Bind<IReportDb>().To<ReportDb>();
            Bind<IDashboardDb>().To<DashboardDb>();

            Bind<IReportStorage>().To<ReportStorage>();
            Bind<IReportRepository>().To<ReportRepository>();

            Bind<IDashboardStorage>().To<DashboardStorage>();
            Bind<IDashboardRepository>().To<DashboardRepository>();

            Bind<IDataBase>().To<DataBase>();
        }
    }
}
