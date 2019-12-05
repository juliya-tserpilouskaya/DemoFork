using BulbaCourses.Analytics.Infrastructure.BLL.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.Infrastructure.BLL.Services
{
    /// <summary>
    /// Provides a mechanism for working Report.
    /// </summary>
    public interface IReportService : IDisposable
    {
        /// <summary>
        /// Creating a new report
        /// </summary>
        /// <param name="reportDto"></param>
        /// <returns></returns>
        IReportDto Create(IReportDto reportDto);

        /// <summary>
        /// Getts all reports
        /// </summary>
        /// <returns></returns>
        IEnumerable<IReportDto> GetAll();

        /// <summary>
        /// Showing report details by Id
        /// </summary>
        /// <returns></returns>
        IReportDto GetById(string Id);

        /// <summary>
        /// Updating Report
        /// </summary>
        /// <param name="reportDto"></param>
        /// <returns></returns>
        IReportDto Update(IReportDto reportDto);

        /// <summary>
        /// Removing report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        void Remove(string Id);
    }
}
