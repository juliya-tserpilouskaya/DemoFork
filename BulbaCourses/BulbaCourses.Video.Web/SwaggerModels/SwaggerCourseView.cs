using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    public class SwaggerCourseView : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CourseView
            {
                Name ="Name",
                Description="Course description",
                Level = Logic.Models.Enums.CourseLevel.Beginner,
                Price =99.99
            };
        }
    }
}