using BulbaCourses.PracticalMaterialsTests.Data.Context;
using Ninject.Modules;
using System.Data.Entity;

namespace BulbaCourses.PracticalMaterialsTests.Data.Modules
{
    public class ModuleNinject_Data : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DbContext_Test>();
        }
    }
}
