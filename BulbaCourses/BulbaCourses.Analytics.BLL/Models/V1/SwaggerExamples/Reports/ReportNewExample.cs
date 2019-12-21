using BulbaCourses.Analytics.Models.V1;
using Swashbuckle.Examples;

namespace BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples.Reports
{
    /// <summary>
    /// Represents a example of model view new report.
    /// </summary>
    public class ReportNewExample : IExamplesProvider
    {
        /// <summary>
        /// Getts a example of model view report.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new ReportNew()
            {
                Name = "Number of requests per day",
                Description = "The dynamics of the number of requests per day",
            };

            return value;
        }
    }
}