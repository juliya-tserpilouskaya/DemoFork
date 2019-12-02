using BulbaCourses.Analytics.BLL.Interfaces;
using BulbaCourses.Analytics.BLL.Services;
using BulbaCourses.Analytics.DAL.Infrastructure;
using BulbaCourses.Analytics.DAL.Interfaces;
using BulbaCourses.Analytics.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {   
            
            //Bind<IDataBase>().To<DataBase>();
            //Bind<IDashboardService>().To<DashboardService>();

            //Bind<ReportService>().ToSelf();
            Bind<IReportService>().To<ReportService>();

        }
    }
}
