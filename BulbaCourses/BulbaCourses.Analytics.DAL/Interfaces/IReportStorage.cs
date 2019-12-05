using BulbaCourses.Analytics.Infrastructure.DAL.Models;
using System.Collections.Generic;

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
        List<IReportDb> Storage { get; }
    }
}
