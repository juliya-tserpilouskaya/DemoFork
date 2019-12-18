using BulbaCourses.Analytics.Web.Models;
using Swashbuckle.Examples;
using System;

namespace BulbaCourses.Analytics.Web.Infrastructure.SwaggerExamples.Reports
{
    public class ReportVmModelExample : IExamplesProvider
    {
        public virtual object GetExamples()
        {
            var value = new ReportVm()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Number of requests per day",
                Description = "The dynamics of the number of requests per day",
                Creator = "Mary Pine",
                Created = DateTime.Now,
                Modifier = "Big boss",
                Modified = DateTime.Now
            };

            return value;
        }
    }
}