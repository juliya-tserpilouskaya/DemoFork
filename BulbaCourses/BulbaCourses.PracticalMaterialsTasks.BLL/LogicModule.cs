using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.BLL.Services;
using BulbaCourses.PracticalMaterialsTasks.DAL;

namespace BulbaCourses.PracticalMaterialsTasks.BLL
{
    public class LogicModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskService>().To<TaskService>();
            this.Kernel?.Load(new[] { new DataModule() });
        }
    }
}
