using System;
using System.Collections.Generic;
using System.Linq;
using Ninject.Modules;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public class DbModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWorkRepository>().To<UnitOfWorkRepository>();
        }
    }
}
