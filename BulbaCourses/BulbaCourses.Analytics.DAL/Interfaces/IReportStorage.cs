using BulbaCourses.Analytics.DAL.Entities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.DAL.Interfaces
{
    /// <summary>
    /// Adds a report repository 
    /// </summary>
    public interface IReportStorage
    {
        /// <summary>
        /// Getts a report repository
        /// </summary>
        List<Report> Storage { get; }
    }
}
