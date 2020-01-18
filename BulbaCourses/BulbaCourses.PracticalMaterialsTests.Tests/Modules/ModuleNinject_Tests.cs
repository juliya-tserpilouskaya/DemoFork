using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.AutoMapper.Profiles;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Interface;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Test.Realization;
using Ninject.Modules;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Modules
{
    public class ModuleNinject_Tests : NinjectModule
    {
        public override void Load()
        {
            // ---------- Service

            Bind<IService_Test>().To<Service_Test>();

            // ---------- DbContext

            Bind<DbContext>().To<DbContext_LocalDb_Test>().WhenTargetHas<AttributeDbContext_LocalDb>();

            // ---------- AutoMapper

            Bind<IMapper>()
                .ToMethod(ctx => 
                    new Mapper(new MapperConfiguration(cfg => 
                    {
                        cfg.AddProfile<AutoMapperProfile_DataLogicLayer>();
                    })));            
        }
    }
}
