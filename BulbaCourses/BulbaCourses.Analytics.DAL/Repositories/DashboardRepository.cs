using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using BulbaCourses.Analytics.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Repositories
{
    public class DashboardRepository : AbstractRepository<Dashboard>
    {
        public DashboardRepository(IDashboardStorage context) :
            base(context.Storage)
        { }
    }
}
