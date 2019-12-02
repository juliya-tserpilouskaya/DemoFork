using BulbaCourses.Analytics.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Interfaces
{
    /// <summary>
    /// Provides a mechanism for working Dashboard.
    /// </summary>
    public interface IDashboardService: ICheckable
    {
        /// <summary>
        /// Showing Dashboard
        /// </summary>
        /// <returns></returns>
        IEnumerable<DashboardDTO> GetDashboards();

        /// <summary>
        /// Showing Dashboard by Id
        /// </summary>
        /// <returns></returns>
        DashboardDTO GetDashboardById(string Id);

        /// <summary>
        /// Creating a new Dashboard
        /// </summary>
        /// <param name="dashboardDTO"></param>
        /// <returns></returns>
        DashboardDTO CreateDashboard(DashboardDTO dashboardDTO);

        /// <summary>
        /// Removing Dashboard by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string RemoveDashboard(string Id);

        /// <summary>
        /// Removing all Dashboards by reportId
        /// </summary>       
        /// <returns></returns>
        string RemoveAllDashboards();

        /// <summary>
        /// Changing Report
        /// </summary>
        /// <param name="dashboardDTO"></param>
        /// <returns></returns>
        DashboardDTO ChangeReport(DashboardDTO dashboardDTO);
    }
}
