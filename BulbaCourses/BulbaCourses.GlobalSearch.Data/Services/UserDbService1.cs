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
    public class UserDbService : IUserDbService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();
        private bool _isDisposed;

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDB> GetAll()
        {
            return _context.Users.Include(b => b.BookmarkItems).Include(q => q.SearchQueryItems);
        }

        /// <summary>
        /// Asynchronously returns all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDB>> GetAllAsync()
        {
            return await _context.Users.Include(b => b.BookmarkItems).Include(q => q.SearchQueryItems).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public UserDB GetById(string id)
        {
            return _context.Users.Include(b => b.BookmarkItems).Include(q => q.SearchQueryItems).SingleOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Asynchronously returns user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public async Task<UserDB> GetByIdAsync(string id)
        {
            return await _context.Users.Include(b => b.BookmarkItems).Include(q => q.SearchQueryItems).SingleOrDefaultAsync(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns></returns>
        public UserDB Add(UserDB user)
        {
            user.Id = Guid.NewGuid().ToString();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns></returns>
        public async Task<Result<UserDB>> AddAsync(UserDB user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Result<UserDB>.Ok(user);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<UserDB>.Fail<UserDB>($"Cannot save User. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<UserDB>.Fail<UserDB>($"Cannot save User. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<UserDB>.Fail<UserDB>($"Invalid User. {e.Message}");
            }
        }

        /// <summary>
        /// Returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public IEnumerable<BookmarkDB> GetBookmarksByUserId(string id)
        {
            return _context.Bookmarks.Where(i => i.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Asynchronously returns bookmarks by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public async Task<IEnumerable<BookmarkDB>> GetBookmarksByUserIdAsync(string id)
        {
            return await _context.Bookmarks.Where(i => i.UserId.Equals(id, StringComparison.OrdinalIgnoreCase)).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public IEnumerable<SearchQueryDB> GetSearchQueriesByUserId(string id)
        {
            return _context.SearchQueries.Where(i => i.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Asynchronously returns search queries by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public async Task<IEnumerable<SearchQueryDB>> GetSearchQueriesByUserIdAsync(string id)
        {
            return await _context.SearchQueries.Where(i => i.UserId.Equals(id, StringComparison.OrdinalIgnoreCase)).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Removes user by id
        /// </summary>
        /// <param name="id">User id</param
        public void RemoveById(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _context.Users.Remove(user);

            //UserDB userToDelete = _context.Users
            //    .Include(b => b.BookmarkItems).Include(q => q.SearchQueryItems)
            //    .SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            //if (userToDelete != null)
            //{
            //    _context.Bookmarks.RemoveRange(userToDelete.BookmarkItems.ToArray());
            //    _context.SearchQueries.RemoveRange(userToDelete.SearchQueryItems.ToArray());
            //    _context.Users.Remove(userToDelete);
            //    _context.SaveChanges();
            //}
            //else
            //{
            //    return false;
            //}
            //return true;
        }

        /// <summary>
        /// Removes user by id
        /// </summary>
        /// <param name="id">User id</param
        public async Task<Result<UserDB>> RemoveByIdAsync(string id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Result<UserDB>.Ok(user);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<UserDB>.Fail<UserDB>($"User not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<UserDB>.Fail<UserDB>($"Invalid User. {e.Message}");
            }
        }

        /// <summary>
        /// Removes all users from database
        /// </summary>
        public void RemoveAll()
        {
            _context.Users.RemoveRange(_context.Users);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~UserDbService()
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
