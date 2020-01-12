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
        private readonly CourseContext categoryContext;

        public CourseCategoryServiceDb(CourseContext context)
        {
            this.categoryContext = context;
        }

        public async Task<CourseCategoryDb> AddAsync(CourseCategoryDb category)
        {
            categoryContext.CourseCategories.Add(category);
            categoryContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(category);
        }

        public async Task<IEnumerable<CourseCategoryDb>> GetAllAsync()
        {
            var categoryList = await categoryContext.CourseCategories.ToListAsync().ConfigureAwait(false);
            return categoryList.AsReadOnly();
        }

        public async Task<CourseCategoryDb> GetByIdAsync(string id)
        {
            var category = await categoryContext.CourseCategories.SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return category;
        }

        public async Task DeleteAsync(CourseCategoryDb categoryDb)
        {
            categoryContext.CourseCategories.Remove(categoryDb);
            await categoryContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var category = categoryContext.CourseCategories.SingleOrDefault(c => c.Id.Equals(id));
            categoryContext.CourseCategories.Remove(category);
            await categoryContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<CourseCategoryDb> UpdateAsync(CourseCategoryDb categoryDb)
        {
            if (categoryDb == null)
            {
                throw new ArgumentNullException("course");
            }
            categoryContext.Entry(categoryDb).State = EntityState.Modified;
            await categoryContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(categoryDb);
        }
    }
}
