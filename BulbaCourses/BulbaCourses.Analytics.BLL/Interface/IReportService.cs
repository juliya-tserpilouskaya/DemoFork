using BulbaCourses.Analytics.BLL.DTO;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Analytics.BLL.Interface
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
        ReportDto Create(ReportDto reportDto);

        /// <summary>
        /// Getts all reports
        /// </summary>
        /// <returns></returns>
        IEnumerable<ReportShortDto> GetAll();

        /// <summary>
        /// Showing report details by Id
        /// </summary>
        /// <returns></returns>
        ReportDto GetById(string Id);

        /// <summary>
        /// Updating Report
        /// </summary>
        /// <param name="reportDto"></param>
        /// <returns></returns>
        ReportDto Update(ReportDto reportDto);

        /// <summary>
        /// Removing report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        void Remove(string Id);
    }
}
