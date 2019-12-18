using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseContext courseContext = new CourseContext();
        
        public CourseService(CourseContext courseService)
        {
            this.courseContext = courseService;
        }
        public IEnumerable<CourseDb> GetAll()
        {
            var coursesList = courseContext.Courses.ToList().AsReadOnly();
            return coursesList;
        }
    }
}
