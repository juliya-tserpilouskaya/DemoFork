using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
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

        public async Task<Result<CourseDb>> AddAsync(CourseDb course)
        {
            try
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseDb>.Ok(course);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseDb>)Result<CourseDb>.Fail<CourseDb>($"Cannot save course. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseDb>)Result<CourseDb>.Fail<CourseDb>($"Cannot save course. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseDb>)Result<CourseDb>.Fail<CourseDb>($"Invalid course. {e.Message}");
            }
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var coursesList = context.Courses.Include(x => x.Domain).ToList().AsReadOnly();
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

        public async Task<Result<CourseDb>> DeleteAsync(CourseDb course)
        {
            try
            {
                context.Courses.Remove(course);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseDb>.Ok(course);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseDb>.Fail<CourseDb>($"Course not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseDb>.Fail<CourseDb>($"Invalid profile. {e.Message}");
            }
        }
        
        public async Task DeleteByIdAsync(string id)
        {
            var course = context.Courses.SingleOrDefault(c => c.Id.Equals(id));
            context.Courses.Remove(course);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Result<CourseDb>> UpdateAsync(CourseDb course)
        {
            try
            {
                if (course == null)
                {
                    throw new ArgumentNullException("course");
                }
                context.Entry(course).State = EntityState.Modified;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseDb>.Ok(course);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseDb>)Result<CourseDb>.Fail<CourseDb>($"Cannot save course. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseDb>)Result<CourseDb>.Fail<CourseDb>($"Invalid course. {e.Message}");
            }
        }
    }
}
