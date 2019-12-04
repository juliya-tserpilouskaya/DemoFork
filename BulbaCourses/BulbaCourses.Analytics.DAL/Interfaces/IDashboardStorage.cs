using BulbaCourses.Analytics.DAL.Entities.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface IDashboardStorage
    {
        List<Dashboard> Storage { get; }
    }
}
