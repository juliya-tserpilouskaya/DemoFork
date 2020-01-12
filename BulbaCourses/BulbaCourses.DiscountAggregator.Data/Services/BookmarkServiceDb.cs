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
    public class BookmarkServiceDb : IBookmarkServiceDb
    {
        private readonly CourseContext context;

        public BookmarkServiceDb(CourseContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddAsync(CourseBookmarkDb bookmark)
        {
            try
            {
                context.CourseBookmarks.Add(bookmark);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (DbEntityValidationException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CourseBookmarkDb>> GetByUserIdAsync(string userId)
        {
            var bookmark = await context.CourseBookmarks.Where(c => c.UserProfile.Id.Equals(userId)).ToListAsync().ConfigureAwait(false); ;
            return bookmark;
        }

        public async Task<bool> DeleteAsync(CourseBookmarkDb bookmarkDb)
        {
            try
            {
                context.CourseBookmarks.Remove(bookmarkDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (DbEntityValidationException)
            {
                return false;
            }
        }
    }
}
