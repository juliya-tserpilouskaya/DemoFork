using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BulbaCourses.DiscountAggregator.Logic.Models;
using Swashbuckle.Examples;

namespace BulbaCourses.DiscountAggregator.Web.SwaggerExamples
{
    public class SwaggerCourse : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Course
            {
                Domain = new Domain()
                {
                    DomainName = "Domain Name",
                    DomainURL = "Domain.by"
                },
                URL = "URL.by",
                Category = new CourseCategory()
                {
                    Name = "Name of Category",
                    Title = "Title of Category"
                },
                Title = "Title of Course",
                Description = "Description of Course",
                Price = 99.99,
                OldPrice = 100,
                DateOldPrice = DateTime.Now,
                Discount = 50,
                DateStartCourse = DateTime.Now,
                DateChange = DateTime.Now
            };
        }
    }
}