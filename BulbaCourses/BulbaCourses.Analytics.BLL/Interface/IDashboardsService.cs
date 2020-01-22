using BulbaCourses.Analytics.BLL.Ensure;
using BulbaCourses.Analytics.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Interface
{
    /// <summary>
    /// Provides a mechanism for working dashboard.
    /// </summary>
    public interface IDashboardsService
    {
        /// <summary>
        /// Creates a new dashboard.
        /// </summary>
        /// <param name="dashboardDto"></param>
        /// <returns></returns>
        Task<DashboardDto> CreateAsync(DashboardDto dashboardDto);

        /// <summary>
        /// Gets all Dashboards.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DashboardDto>> GetAllAsync();

        /// <summary>
        /// Shows a dashboard details by id.
        /// </summary>
        /// <returns></returns>
        Task<DashboardDto> GetByIdAsync(string id);        

        /// <summary>
        /// Updates a dashboard.
        /// </summary>
        /// <param name="dashboard"></param>
        /// <returns></returns>
        Task<DashboardDto> UpdateAsync(DashboardDto dashboard);

        /// <summary>
        /// Removes a dashboard by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string id);

        /// <summary>
        /// Checks if a dashboard exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsIdAsync(string id);

        /// <summary>
        /// Checks if a report exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsReportIdAsync(string id);

        /// <summary>
        /// Checks if a chart exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsChartIdAsync(int id);
    }
}
