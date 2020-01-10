using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services
{
    class BookmarkDbService : IBookmarkDbService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();
        private bool _isDisposed;

        public BookmarkDB Add(BookmarkDB bookmark)
        {
            bookmark.Id = Guid.NewGuid().ToString();
            _context.Bookmarks.Add(bookmark);
            return bookmark;
        }

        public IEnumerable<BookmarkDB> GetAll()
        {
            return _context.Bookmarks;
        }

        public async Task<IEnumerable<BookmarkDB>> GetAllAsync()
        {
            return await _context.Bookmarks.ToListAsync().ConfigureAwait(false);
        }

        public BookmarkDB GetById(string id)
        {
            return _context.Bookmarks.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<BookmarkDB> GetByIdAsync(string id)
        {
            return await _context.Bookmarks.SingleOrDefaultAsync(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<BookmarkDB> GetByUserId(string userID)
        {
            return _context.Bookmarks.Where(b => b.UserId == userID);
        }

        public async Task<IEnumerable<BookmarkDB>> GetByUserIdAsync(string userID)
        {
            return await _context.Bookmarks.Where(b => b.UserId == userID).ToListAsync().ConfigureAwait(false);
        }

        public void RemoveAll()
        {
            _context.Bookmarks.RemoveRange(_context.Bookmarks);
        }

        public void RemoveById(string id)
        {
            var bookmark = _context.Bookmarks.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _context.Bookmarks.Remove(bookmark);
        }
        public void Dispose()
        {
            Dispose(true);
        }

        ~BookmarkDbService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed)
            {
                return;
            }

            _context.Dispose();
            _isDisposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
