using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BulbaCourses.Analytics.Models.V1
{
    /// <summary>
    /// Represents a model view dashboard short.
    /// </summary>
    public class DashboardData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the dashboard.
        /// </summary>
        public string Id { get; set; }

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

        /// <summary>
        /// Gets Dates for analytic.
        /// </summary>
        public IEnumerable<string> Dates { get; set; }

        /// <summary>
        /// Gets Values for analytic.
        /// </summary>
        public IEnumerable<double> Values { get; set; }
    }
}