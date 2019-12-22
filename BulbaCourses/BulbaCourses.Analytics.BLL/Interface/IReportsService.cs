using BulbaCourses.Analytics.BLL.Ensure;
using BulbaCourses.Analytics.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Interface
{
    /// <summary>
    /// Provides a mechanism for working Report.
    /// </summary>
    public interface IReportsService
    {
        /// <summary>
        /// Creates a new report.
        /// </summary>
        /// <param name="reportDto"></param>
        /// <returns></returns>
        Task<ReportDto> CreateAsync(ReportDto reportDto);

        /// <summary>
        /// Gets all reports.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ReportDto>> GetAllAsync();

        /// <summary>
        /// Shows a report details by id.
        /// </summary>
        /// <returns></returns>
        Task<ReportDto> GetByIdAsync(string id);

        /// <summary>
        /// Shows a reports details by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="stringOption"></param>
        /// <returns></returns>
        Task<IEnumerable<ReportDto>> GetAllByNameAsync(string name, Search.StringOption stringOption);

        /// <summary>
        /// Updates a report.
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        Task<ReportDto> UpdateAsync(ReportDto report);

        /// <summary>
        /// Removes a report by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string id);

        /// <summary>
        /// Checks if a report exists by Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> ExistsNameAsync(string name);

        /// <summary>
        /// Checks if a report exists by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsIdAsync(string id);               
    }
}
