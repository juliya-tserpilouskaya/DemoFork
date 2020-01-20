using AutoMapper;
using BulbaCourses.DiscountAggregator.Logic;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.DiscountAggregator.Web
{
    public class AutoMapperLoad : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperLogicProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}