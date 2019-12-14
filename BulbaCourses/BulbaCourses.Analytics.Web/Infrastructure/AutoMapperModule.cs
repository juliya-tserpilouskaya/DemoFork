using AutoMapper;
using BulbaCourses.Analytics.BLL.Infrastructure.Assemblies;
using Ninject.Modules;

namespace BulbaCourses.Analytics.Web.Infrastructure
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    var profiles = AssemblyHelper.GetInstancedObjects<Profile>("BulbaCourses.Analytics.");
                    if (profiles != null)
                    {
                        cfg.AddProfiles(profiles);
                    }
                });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}