using BulbaCourses.Video.Web.Models.CourseViews;
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
                CourseId = "fd3011b4-ced6-4cc2-ae41-72201aaea41c",
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