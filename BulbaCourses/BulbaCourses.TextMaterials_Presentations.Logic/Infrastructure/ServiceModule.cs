using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.TextMaterials_Presentations.Data;

namespace BulbaCourses.TextMaterials_Presentations.Logic.Infrastructure
{
    class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWorkRepository>().To<UnitOfWorkRepository>();
        }
    }
}
