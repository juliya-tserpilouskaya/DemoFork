using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.PracticalMaterialsTasks.DAL.Context;

namespace BulbaCourses.PracticalMaterialsTasks.DAL
{
    public  class DataModule: NinjectModule
    {
        public override void Load()
        {
            Bind<TasksContext>().ToSelf();
        }
    }
}
