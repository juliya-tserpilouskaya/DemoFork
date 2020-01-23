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
    public class BookmarkServiceDb : IBookmarkServiceDb
    {
        private readonly DAContext context;

        public BookmarkServiceDb(DAContext context)
        {
            this.context = context;
        }

        public async Task<Result<CourseBookmarkDb>> AddAsync(CourseBookmarkDb bookmarkDb)
        {
            try
            {
                context.CourseBookmarks.Add(bookmarkDb);
                await context.SaveChangesAsync();
                return Result<CourseBookmarkDb>.Ok(bookmarkDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseBookmarkDb>.Fail<CourseBookmarkDb>($"Cannot save bookmark. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<CourseBookmarkDb>.Fail<CourseBookmarkDb>($"Cannot save bookmark. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseBookmarkDb>.Fail<CourseBookmarkDb>($"Invalid bookmark. {e.Message}");
            }
        }

        public async Task<IEnumerable<CourseBookmarkDb>> GetByUserIdAsync(string userId)
             => await context.CourseBookmarks.Where(c => c.UserProfile.Id.Equals(userId)).ToListAsync().ConfigureAwait(false);
           

        public async Task<Result<CourseBookmarkDb>> DeleteAsync(CourseBookmarkDb bookmarkDb)
        {
            try
            {
                context.CourseBookmarks.Remove(bookmarkDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseBookmarkDb>.Ok(bookmarkDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseBookmarkDb>.Fail<CourseBookmarkDb>($"Bookmark not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseBookmarkDb>.Fail<CourseBookmarkDb>($"Invalid bookmark. {e.Message}");
            }
        }
    }
}
