using System.ComponentModel.DataAnnotations;

namespace BulbaCourses.Analytics.Models.V1
{
    /// <summary>
    /// Represents a model view new report.
    /// </summary>
    public class ReportNew
    {
        /// <summary>
        /// Gets or sets the name for the report.
        /// </summary>
        [Required] 
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for the report.
        /// </summary>
        public string Description { get; set; }
    }
}