using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
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

        public void Add(CourseBookmarkDb bookmark)
        {
            context.CourseBookmarks.Add(bookmark);
            context.SaveChanges();
        }

        public IEnumerable<CourseBookmarkDb> GetAll()
        {
            var bookmarks = context.CourseBookmarks.ToList().AsReadOnly();
            return bookmarks;
        }

        public void Delete(CourseBookmarkDb bookmark)
        {
            context.CourseBookmarks.Remove(bookmark);
            context.SaveChanges();
        }
    }
}
