using BulbaCourses.Analytics.DAL.Entities.Coupling;
using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using BulbaCourses.Analytics.DAL.Entities.Reports;
using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class DataBase : IDataBase
    {
        public IRepository<Report> Reports { get; set; }

        public IRepository<Dashboard> Dashboards { get; }

        public IRepository<Links> Links { get; }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
