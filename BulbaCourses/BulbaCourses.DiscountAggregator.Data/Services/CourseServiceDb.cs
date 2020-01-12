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

        public async Task<CourseDb> AddAsync(CourseDb course)
        {
            courseContext.Courses.Add(course);
            courseContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(course);
        }
        

        public IEnumerable<CourseDb> GetAll()
        {
            var coursesList = courseContext.Courses.ToList().AsReadOnly();
            return coursesList;
        }
        
        public async Task<IEnumerable<CourseDb>> GetAllAsync()
        {
            var coursesList = await courseContext.Courses.ToListAsync().ConfigureAwait(false);
            return coursesList.AsReadOnly();
        }

        public CourseDb GetById(string id)
        {
            var course = courseContext.Courses.FirstOrDefault(c => c.Id.Equals(id));
            return course;
        }
        
        public async Task<CourseDb> GetByIdAsync(string id)
        {
            var course = await courseContext.Courses.SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return course;
        }

        public async Task DeleteAsync(CourseDb course)
        {
            courseContext.Courses.Remove(course);
            await courseContext.SaveChangesAsync().ConfigureAwait(false);
        }
        
        public async Task DeleteByIdAsync(string id)
        {
            var course = courseContext.Courses.SingleOrDefault(c => c.Id.Equals(id));
            courseContext.Courses.Remove(course);
            await courseContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<CourseDb> UpdateAsync(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            courseContext.Entry(course).State = EntityState.Modified;
            await courseContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(course);
        }
    }
}
