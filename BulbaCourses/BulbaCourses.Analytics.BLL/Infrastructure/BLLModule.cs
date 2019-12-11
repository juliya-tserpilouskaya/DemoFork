using BulbaCourses.Analytics.BLL.Interface;
using BulbaCourses.Analytics.BLL.Services;
using Ninject.Modules;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<IValidation>().To<Validation>().InSingletonScope();
            Bind<IReportService>().To<ReportService>();
        }
    }
}
