using BulbaCourses.PracticalMaterialsTests.Data.Context;
using Ninject.Modules;

namespace BulbaCourses.PracticalMaterialsTests.Data.Modules
{
    public class ModuleNinject_Data : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext_Test>().ToSelf();
        }
    }
}
