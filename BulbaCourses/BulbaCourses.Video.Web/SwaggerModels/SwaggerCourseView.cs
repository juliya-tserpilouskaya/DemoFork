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
                CourseId = Guid.NewGuid().ToString(),
                Name ="Name",
                Description="Course description",
                Duration = 100,
                Level = Enums.CourseLevel.Beginner,
                Raiting = 4.6,
                Price =99.99
            };
        }
    }
}