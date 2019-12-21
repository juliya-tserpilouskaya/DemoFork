using Swashbuckle.Examples;
using System;

namespace BulbaCourses.Analytics.BLL.Models.V1.SwaggerExamples.Reports
{
    /// <summary>
    /// Represents a example of model view report.
    /// </summary>
    public class ReportIdExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view report.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new ReportId()
            {
                Id = Guid.NewGuid().ToString()               
            };

            return value;
        }
    }
}