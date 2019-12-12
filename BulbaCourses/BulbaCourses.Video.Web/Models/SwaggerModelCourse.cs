using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    public class SwaggerModelCourse : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CourseView
            {
                CourseId = Guid.NewGuid().ToString(),
                Name ="Name"

            };
        }
    }
}