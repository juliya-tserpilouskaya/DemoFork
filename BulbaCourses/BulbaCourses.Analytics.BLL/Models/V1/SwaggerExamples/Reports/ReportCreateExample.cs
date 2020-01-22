using BulbaCourses.Analytics.Models.V1;
using Swashbuckle.Examples;

namespace BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples
{
    /// <summary>
    /// Represents a example of model view new report.
    /// </summary>
    public class ReportCreateExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view report.
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