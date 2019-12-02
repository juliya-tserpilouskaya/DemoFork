using BulbaCourses.Analytics.DAL.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    public interface IReportStorage
    {
        List<Report> Storage { get; }
    }
}
