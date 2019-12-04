using BulbaCourses.Analytics.DAL.Entities.Coupling;
using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using BulbaCourses.Analytics.DAL.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface IDataBase
    {
        IRepository<Report> Reports { get; set; }

        IRepository<Dashboard> Dashboards { get; }

        IRepository<Links> Links { get; }

        void Dispose();
    }
}
