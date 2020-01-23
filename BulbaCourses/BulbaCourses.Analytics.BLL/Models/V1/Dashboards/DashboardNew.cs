using System.ComponentModel.DataAnnotations;

namespace BulbaCourses.Analytics.Models.V1
{
    /// <summary>
    /// Represents a model view dashboard short.
    /// </summary>
    public class DashboardNew
    {
        /// <summary>
        /// Gets or sets the name for the dashboard.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the report.
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the chart.
        /// </summary>
        public int ChartId { get; set; }


    }
}