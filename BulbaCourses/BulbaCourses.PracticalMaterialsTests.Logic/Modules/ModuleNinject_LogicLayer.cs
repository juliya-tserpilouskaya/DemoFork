using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Attributes.DbContext;
using BulbaCourses.PracticalMaterialsTests.Logic.AutoMapper.Profiles;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.WorkWithResultTest.Interface;
using Ninject.Modules;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Modules
{
    public class ModuleNinject_LogicLayer : NinjectModule
    {
        public override void Load()
        {
            // ---------- DbContext

            Bind<DbContext>().To<DbContext_LocalDb_Test>().WhenTargetHas<AttributeDbContext_LocalDb>();

            // ---------- IService

            Bind<IService_WorkWithResultTest>().To<Service_WorkWithResultTest>();

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
