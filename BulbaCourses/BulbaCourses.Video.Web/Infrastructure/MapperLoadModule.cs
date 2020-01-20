using AutoMapper;
using BulbaCourses.Video.Logic.Infrastructure;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Infrastructure
{
    public class MapperLoadModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperLogicProfile>();
                c.AddProfile<MapperWebProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}