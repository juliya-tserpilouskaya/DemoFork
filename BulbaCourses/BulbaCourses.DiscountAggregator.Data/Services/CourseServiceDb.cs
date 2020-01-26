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
            var coursesList = context.Courses
                .Include(x => x.Domain)
                .Include(y => y.Category).ToList().AsReadOnly();
            return coursesList;
        }
        
        public async Task<IEnumerable<CourseDb>> GetAllAsync()
        {
            var coursesList = await context.Courses
                .Include(x => x.Domain)
                .Include(y => y.Category).ToListAsync().ConfigureAwait(false);
            return coursesList.AsReadOnly();
        }

        public CourseDb GetById(string id)
        {
            var course = context.Courses
                .Include(x => x.Domain)
                .Include(y => y.Category).FirstOrDefault(c => c.Id.Equals(id));
            return course;
        }
        
        public async Task<CourseDb> GetByIdAsync(string id)
        {
            var course = await context.Courses
                .Include(x => x.Domain)
                .Include(y => y.Category).SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return course;
        }

        public async Task<IEnumerable<CourseDb>> GetByIdUserAsync(string idUser)
        {
            var criteria = context.Profiles.Include(x => x.SearchCriteria)
                .Include(x => x.SearchCriteria.Domains)
                .Include(x => x.SearchCriteria.CourseCategories)
                .Where(p => p.Id == idUser).FirstOrDefault();

            //var domain = (IEnumerable<DomainDb>)criteria.SearchCriteria.Domains;

            var courses = await context.Courses
                .Include(i => i.Domain)
                .Include(c => c.Category)
                .Where(x => x.Price >= criteria.SearchCriteria.MinPrice
                && x.Price <= criteria.SearchCriteria.MaxPrice
                //&& domain.Any(y => y.DomainURL == x.Domain.DomainURL)//   criteria.SearchCriteria.Domains.Contains(x.Domain)
                //&& criteria.SearchCriteria.CourseCategories.Contains(x.Category)
                //&& domain.Any(a => a.DomainURL == x.Domain.DomainURL)
                //&& x.Domain == context.Domains.FirstOrDefault(f => f.DomainURL == @"/specialization/web-dizayn/")
                && x.Discount >= criteria.SearchCriteria.MinDiscount && x.Discount <= criteria.SearchCriteria.MaxDiscount)
                .ToListAsync()
                .ConfigureAwait(false);
            //TODO domain and category
            //var searchCriteriaDb = context.SearchCriterias.Find(idSearch);
            //var courses = await context.Courses
            //    .Where(x => x.Price >= searchCriteriaDb.MinPrice 
            //    && x.Price <= searchCriteriaDb.MaxPrice 
            //    //&& x.Domain == searchCriteriaDb.Domains
            //    //&& x.Category == searchCriteriaDb.CourseCategories
            //    && x.Discount >= searchCriteriaDb.MinDiscount && x.Discount <= searchCriteriaDb.MaxDiscount)
            //    .ToListAsync()
            //    .ConfigureAwait(false);

            return courses;
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
        
        public async Task<Result<CourseDb>> DeleteByIdAsync(string id)
        {
            try
            {
                var course = context.Courses
                    .Include(x => x.Domain)
                    .Include(y => y.Category).SingleOrDefault(c => c.Id.Equals(id));
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

        public async Task<Result<CourseDb>> UpdateAsync(CourseDb course)
        {
            try
            {
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
