using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

        public async Task<Result<CourseCategoryDb>> AddAsync(CourseCategoryDb category)
        {
            try
            {
                context.CourseCategories.Add(category);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseCategoryDb>.Ok(category);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseCategoryDb>)Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Cannot save category. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseCategoryDb>)Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Cannot save category. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseCategoryDb>)Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Invalid category. {e.Message + "/n" + e.EntityValidationErrors}");
            }
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

        public async Task<Result<CourseCategoryDb>> DeleteAsync(CourseCategoryDb categoryDb)
        {
            try
            {
                context.CourseCategories.Remove(categoryDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseCategoryDb>.Ok(categoryDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Category not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Invalid category. {e.Message}");
            }

        }

        public async Task<Result<CourseCategoryDb>> DeleteByIdAsync(string id)
        {
            try
            {
                var categoryDb = context.CourseCategories.SingleOrDefault(c => c.Id.Equals(id));
                context.CourseCategories.Remove(categoryDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseCategoryDb>.Ok(categoryDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Category not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Invalid category. {e.Message}");
            }
        }

        public async Task<Result<CourseCategoryDb>> UpdateAsync(CourseCategoryDb categoryDb)
        {
            try
            {
                if (categoryDb == null)
                {
                    throw new ArgumentNullException("category");
                }
                context.Entry(categoryDb).State = EntityState.Modified;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseCategoryDb>.Ok(categoryDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<CourseCategoryDb>)Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Cannot save category. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<CourseCategoryDb>)Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Cannot save category. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<CourseCategoryDb>)Result<CourseCategoryDb>.Fail<CourseCategoryDb>($"Invalid category. {e.Message}");
            }

        }
    }
}
