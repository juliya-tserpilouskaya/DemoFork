using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class CourseCategoryServiceDb : ICourseCategoryServiceDb
    {
        private readonly DAContext context;

        public CourseCategoryServiceDb(DAContext context)
        {
            this.context = context;
        }

        public async Task<CourseCategoryDb> AddAsync(CourseCategoryDb category)
        {
            context.CourseCategories.Add(category);
            context.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(category);
        }

        public async Task<IEnumerable<CourseCategoryDb>> GetAllAsync()
        {
            var categoryList = await context.CourseCategories.ToListAsync().ConfigureAwait(false);
            return categoryList.AsReadOnly();
        }

        public async Task<CourseCategoryDb> GetByIdAsync(string id)
        {
            var category = await context.CourseCategories.SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return category;
        }

        public async Task DeleteAsync(CourseCategoryDb categoryDb)
        {
            context.CourseCategories.Remove(categoryDb);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var category = context.CourseCategories.SingleOrDefault(c => c.Id.Equals(id));
            context.CourseCategories.Remove(category);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<CourseCategoryDb> UpdateAsync(CourseCategoryDb categoryDb)
        {
            if (categoryDb == null)
            {
                throw new ArgumentNullException("course");
            }
            context.Entry(categoryDb).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(categoryDb);
        }
    }
}
