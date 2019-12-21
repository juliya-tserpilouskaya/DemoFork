using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.BLL.Services;
using BulbaCourses.Analytics.DAL.Interface;
using BulbaCourses.Analytics.DAL.Models;
using BulbaCourses.Analytics.DAL.Repositories;
using Ninject.Modules;

namespace BulbaCourses.Analytics.BLL.Ensure
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<IReportsService>().To<ReportsService>();
            Bind<IRepository<ReportDb>>().To<ReportRepository>();
        }
    }
}
