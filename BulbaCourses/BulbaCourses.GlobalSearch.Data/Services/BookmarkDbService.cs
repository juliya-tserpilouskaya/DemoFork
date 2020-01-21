using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services
{
    public class BookmarkDbService : IBookmarkDbService
    {
        private GlobalSearchContext _context;

        private bool _isDisposed;

        public BookmarkDbService()
        {
            this._context = new GlobalSearchContext();
        }

        public BookmarkDbService(GlobalSearchContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Returns all bookmarks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookmarkDB> GetAll()
        {
            return _context.Bookmarks;
        }

        /// <summary>
        /// Asynchronously returns all bookmarks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookmarkDB>> GetAllAsync()
        {
            return await _context.Bookmarks.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns bookmark by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        public BookmarkDB GetById(string id)
        {
            return _context.Bookmarks.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Asynchronously returns bookmark by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        public async Task<BookmarkDB> GetByIdAsync(string id)
        {
            return await _context.Bookmarks.SingleOrDefaultAsync(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        public IEnumerable<BookmarkDB> GetByUserId(string userID)
        {
            return _context.Bookmarks.Where(b => b.UserId == userID);
        }

        /// <summary>
        /// Asynchronously returns bookmark by user id
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        public async Task<IEnumerable<BookmarkDB>> GetByUserIdAsync(string userID)
        {
            return await _context.Bookmarks.Where(b => b.UserId == userID).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Creates new bookmark
        /// </summary>
        /// <param name="bookmark">New user</param>
        /// <returns></returns>
        public BookmarkDB Add(BookmarkDB bookmark)
        {
            bookmark.Id = Guid.NewGuid().ToString();
            _context.Bookmarks.Add(bookmark);
            return bookmark;
        }

        public async Task<Result<BookmarkDB>> AddAsync(BookmarkDB bookmark)
        {
            try
            {
                bookmark.Id = Guid.NewGuid().ToString();
                _context.Bookmarks.Add(bookmark);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Result<BookmarkDB>.Ok(bookmark);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<BookmarkDB>.Fail<BookmarkDB>($"Cannot save bookmark. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<BookmarkDB>.Fail<BookmarkDB>($"Cannot save bookmark. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<BookmarkDB>.Fail<BookmarkDB>($"Invalid bookmark. {e.Message}");
            }
        }

        /// <summary>
        /// Removes bookmarks by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        public void RemoveById(string id)
        {
            var bookmark = _context.Bookmarks.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _context.Bookmarks.Remove(bookmark);
        }

        /// <summary>
        /// Removes bookmarks by id
        /// </summary>
        /// <param name="id">Bookmark id</param>
        /// <returns></returns>
        public async Task<Result<BookmarkDB>> RemoveByIdAsync(string id)
        {
            try
            {
                var bookmark = _context.Bookmarks.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
                _context.Bookmarks.Remove(bookmark);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Result<BookmarkDB>.Ok(bookmark);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<BookmarkDB>.Fail<BookmarkDB>($"Bookmark not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<BookmarkDB>.Fail<BookmarkDB>($"Bookmark SearchCriteria. {e.Message}");
            }
        }

        /// <summary>
        /// Removes all bookmarks from database
        /// </summary>
        public void RemoveAll()
        {
            _context.Bookmarks.RemoveRange(_context.Bookmarks);
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
