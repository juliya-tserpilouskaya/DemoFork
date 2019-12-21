using AutoMapper;
using Ninject.Modules;

namespace BulbaCourses.Analytics.Web.Ensure
{
    /// <summary>
    /// Represents a module AutoMapper for NinjectModule.
    /// </summary>
    public class AutoMapperModule : NinjectModule
    {
        /// <summary>
        /// Loads a AutoMapper configuration and Ninject binding.
        /// </summary>
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps("BulbaCourses.Analytics.BLL");
                });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}