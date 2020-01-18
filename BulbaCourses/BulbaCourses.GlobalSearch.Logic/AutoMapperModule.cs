using AutoMapper;
using BulbaCourses.GlobalSearch.Logic.Infrastructure;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperLogicProfile>();
            });

            var mapper = config.CreateMapper();
            Bind<MapperConfiguration>().ToConstant(config).InSingletonScope();
            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
        }
    }
}
