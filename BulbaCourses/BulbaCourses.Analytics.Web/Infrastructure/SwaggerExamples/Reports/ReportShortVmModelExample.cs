using BulbaCourses.Analytics.Web.Models;
using Swashbuckle.Examples;
using System;

namespace BulbaCourses.Analytics.Web.Infrastructure.SwaggerExamples.Reports
{
    public class ReportShortVmModelExample : IExamplesProvider
    {
        public virtual object GetExamples()
        {
            var value = new ReportShortVm()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Number of requests per day",
            };

            return value;
        }
    }
}