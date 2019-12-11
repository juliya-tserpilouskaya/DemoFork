using AutoMapper;
using Ninject.Modules;

namespace BulbaCourses.Analytics.Web.Infrastructure
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BulbaCourses.Analytics.BLL.Infrastructure.MappingProfiles.ReportProfile>();
                cfg.AddProfile<BulbaCourses.Analytics.Web.Infrastructure.MappingProfiles.ReportProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}