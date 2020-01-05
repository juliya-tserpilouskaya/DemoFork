using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BulbaCourses.PracticalMaterialsTasks.DAL.Interfaces;
using BulbaCourses.PracticalMaterialsTasks.DAL.Repositories;

namespace BulbaCourses.PracticalMaterialsTasks.BLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {

        private string ConnectionString;
        public ServiceModule(string connection)
        {
            ConnectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(ConnectionString);
        }

    }
}
