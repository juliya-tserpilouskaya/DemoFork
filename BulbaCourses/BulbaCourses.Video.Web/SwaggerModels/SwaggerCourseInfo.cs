using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.SwaggerModels
{
    public class SwaggerCourseInfo : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Logic.Models.CourseInfo
            {
                Name = "Name",
                Description = "Course description",
                Duration = 100,
                Level = 1,
                Raiting = 4.6,
                Price = 99.99
            };
        }
    }
}