using BulbaCourses.Analytics.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Interfaces
{
    /// <summary>
    /// Provides a mechanism for working Report.
    /// </summary>
    public interface IReportService: IDisposable
    {
        /// <summary>
        /// Getting DashboardService
        /// </summary>
        IDashboardService DashboardService { get; }

        /// <summary>
        /// Showing list reports
        /// </summary>
        /// <returns></returns>
        IEnumerable<ReportShortDTO> GetReportsShort();

        /// <summary>
        /// Showing report by Name
        /// </summary>
        /// <returns></returns>
        ReportDTO GetReportByName(string name);

        /// <summary>
        /// Showing report details by Id
        /// </summary>
        /// <returns></returns>
        ReportDTO GetReportById(string Id);

        /// <summary>
        /// Creating a new report
        /// </summary>
        /// <param name="reportDTO"></param>
        /// <returns></returns>
        ReportDTO CreateReport(ReportDTO reportDTO);

        /// <summary>
        /// Removing report by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        void RemoveReport(string Id);

        /// <summary>
        /// Changing Report
        /// </summary>
        /// <param name="reportDTO"></param>
        /// <returns></returns>
        ReportDTO ChangeReport(ReportDTO reportDTO);
    }
}
