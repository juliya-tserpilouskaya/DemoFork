using AutoMapper;
using BulbaCourses.PracticalMaterialsTests.Data.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.AutoMap;
using Ninject.Modules;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Modules
{
    public class ModuleNinject_Logic : NinjectModule
    {
        public override void Load()
        {
            // ---------- AutoMapper

            Bind<IMapper>().ToMethod(ctx => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile_Logic>();
            })));

            // ---------- LayerData

            this.Kernel?.Load(new[] { new ModuleNinject_Data() });
        }
    }
}
