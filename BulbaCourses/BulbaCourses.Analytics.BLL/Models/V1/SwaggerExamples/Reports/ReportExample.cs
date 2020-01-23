using BulbaCourses.Analytics.Models.V1;
using Swashbuckle.Examples;
using System;

namespace BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples
{
    /// <summary>
    /// Represents a example of model view report.
    /// </summary>
    public class ReportExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view report.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new Report()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Number of requests per day",
                Description = "The dynamics of the number of requests per day",
            };

            return value;
        }
    }
}