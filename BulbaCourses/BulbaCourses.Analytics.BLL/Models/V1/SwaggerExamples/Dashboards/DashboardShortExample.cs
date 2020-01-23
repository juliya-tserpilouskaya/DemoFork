using BulbaCourses.Analytics.Models.V1;
using Swashbuckle.Examples;
using System;

namespace BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples
{
    /// <summary>
    /// Represents a example of model view dashboard short.
    /// </summary>
    public class DashboardShortExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view dashboard short.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new DashboardShort()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Exchange rates per day",
                ReportId = Guid.NewGuid().ToString(),
                ChartId = 1
            };

            return value;
        }
    }
}