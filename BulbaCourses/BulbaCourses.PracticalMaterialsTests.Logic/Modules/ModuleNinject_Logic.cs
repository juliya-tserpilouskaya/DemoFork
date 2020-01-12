using BulbaCourses.PracticalMaterialsTests.Data.Modules;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization;
using Ninject.Modules;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Modules
{
    public class ModuleNinject_Logic : NinjectModule
    {
        public override void Load()
        {
            Bind<IService_Test>().To<Service_Test>();

            this.Kernel?.Load(new[] { new ModuleNinject_Data() });
        }
    }
}
