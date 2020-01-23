using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.PracticalMaterialsTasks.BLL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.BLL.Services;
using BulbaCourses.PracticalMaterialsTasks.DAL;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Repositories;
using FluentValidation;
using BulbaCourses.PracticalMaterialsTasks.BLL.Validators;

namespace BulbaCourses.PracticalMaterialsTasks.BLL
{
    public class LogicModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ITaskService>().To<TaskService>();
            //Bind<IValidator>().To<TaskValidator>();
            //Bind<IUnitOfWork>().To<EFUnitOfWork>();
            //this.Kernel?.Load(new[] { new DataModule() });
        }
    }
}
