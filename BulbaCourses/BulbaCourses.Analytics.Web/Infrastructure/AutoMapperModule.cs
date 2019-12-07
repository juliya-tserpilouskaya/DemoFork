using AutoMapper;
using BulbaCourses.Analytics.Web.MappingProfiles;
using Ninject.Modules;
using System;
using System.Linq;

namespace BulbaCourses.Analytics.Web.Infrastructure
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ReportProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}