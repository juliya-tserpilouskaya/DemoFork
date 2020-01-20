using BulbaCourses.Video.Web.Models;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.SwaggerModels
{
    public class SwaggerCourseViewInput : IExamplesProvider
    {
        public object GetExamples()
        {
            return new CourseViewInput
            {
                Name = "Course name",
                Description = "Course description",
                Level = Logic.Models.Enums.CourseLevel.Beginner,
                Price = 99.99
            };
        }

    }
}