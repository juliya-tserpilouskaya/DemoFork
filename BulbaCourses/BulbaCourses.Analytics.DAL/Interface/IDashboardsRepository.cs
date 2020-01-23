using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Analytics.DAL.Models;

namespace BulbaCourses.Analytics.DAL.Interface
{
    /// <summary>
    /// Represents a mechanism for working dashboards repository.
    /// </summary>
    public interface IDashboardsRepository: IRepository<DashboardDb>
    {
        /// <summary>
        /// Gets true if the chart exists, otherwise false.
        /// </summary>
        /// <param name="anyAsyncCondition"></param>
        /// <returns></returns>
        Task<bool> ExistsChartAsync(
            Expression<Func<ChartDb, bool>> anyAsyncCondition);

        /// <summary>
        /// Gets true if the report exists, otherwise false.
        /// </summary>
        /// <param name="anyAsyncCondition"></param>
        /// <returns></returns>
        Task<bool> ExistsReportAsync(
            Expression<Func<ReportDb, bool>> anyAsyncCondition);
    }
}
