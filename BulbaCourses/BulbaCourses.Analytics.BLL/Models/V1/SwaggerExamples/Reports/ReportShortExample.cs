using BulbaCourses.Analytics.Models.V1;
using Swashbuckle.Examples;
using System;

namespace BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples
{
    /// <summary>
    /// Represents a example of model view report short.
    /// </summary>
    public class ReportShortExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view report short.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new ReportShort()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Number of requests per day",
            };

            return value;
        }
    }
}