using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class CourseServiceDb : ICourseService
    {
        private readonly DAContext context;
        
        public CourseServiceDb(DAContext courseService)
        {
            this.context = courseService;
        }

        public async Task<CourseDb> AddAsync(CourseDb course)
        { 
            context.Courses.Add(course);
            context.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(course);
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var coursesList = context.Courses.ToList().AsReadOnly();
            return coursesList;
        }
        
        public async Task<IEnumerable<CourseDb>> GetAllAsync()
        {
            var coursesList = await context.Courses.ToListAsync().ConfigureAwait(false);
            return coursesList.AsReadOnly();
        }

        public CourseDb GetById(string id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id.Equals(id));
            return course;
        }
        
        public async Task<CourseDb> GetByIdAsync(string id)
        {
            var course = await context.Courses.SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return course;
        }

        public async Task DeleteAsync(CourseDb course)
        {
            context.Courses.Remove(course);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        
        public async Task DeleteByIdAsync(string id)
        {
            var course = context.Courses.SingleOrDefault(c => c.Id.Equals(id));
            context.Courses.Remove(course);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<CourseDb> UpdateAsync(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            context.Entry(course).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(course);
        }
    }
}
