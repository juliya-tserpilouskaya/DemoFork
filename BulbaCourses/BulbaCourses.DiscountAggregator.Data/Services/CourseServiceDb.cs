using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class CourseServiceDb : ICourseService
    {
        private readonly CourseContext courseContext;
        
        public CourseServiceDb(CourseContext courseService)
        {
            this.courseContext = courseService;
        }

        public void Add(CourseDb course)
        {
            courseContext.Courses.Add(course);
            courseContext.SaveChanges();
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var coursesList = courseContext.Courses.ToList().AsReadOnly();
            return coursesList;
        }

        public CourseDb GetById(string id)
        {
            var course = courseContext.Courses.FirstOrDefault(c => c.Id.Equals(id));
            return course;
        }

        public void Delete(CourseDb course)
        {
            courseContext.Courses.Remove(course);
            courseContext.SaveChanges();
        }

        public void Update(CourseDb course)
        {
            if(course != null)
            {
                courseContext.Entry(course).State = EntityState.Modified;
                courseContext.SaveChanges();
            } 
        }
    }
}
