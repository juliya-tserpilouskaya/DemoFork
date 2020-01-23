using Ninject.Modules;
using AutoMapper;
using BulbaCourses.GlobalAdminUser.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalAdminUser.Web.Infrastructure
{
    public class MapperLoadModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperLogicProfile>();
                cfg.AddProfile<MapperWebProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}