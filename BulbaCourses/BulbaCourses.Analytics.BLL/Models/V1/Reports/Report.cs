namespace BulbaCourses.Analytics.Models.V1
{
    /// <summary>
    /// Represents a model view report.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Gets or sets the unique identifier for the report.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name for the report.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description for the report.
        /// </summary>
        public string Description { get; set; }
    }
}