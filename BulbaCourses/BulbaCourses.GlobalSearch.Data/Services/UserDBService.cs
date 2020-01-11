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
    class UserDBService : IUserService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();
        private bool _isDisposed;

        public UserDB Add(UserDB user)
        {
            user.Id = Guid.NewGuid().ToString();
            _context.Users.Add(user);
            return user;
        }

        public IEnumerable<UserDB> GetAll()
        {
            return _context.Users;
        }

        public async Task<IEnumerable<UserDB>> GetAllAsync()
        {
            return await _context.Users.ToListAsync().ConfigureAwait(false);
        }

        public UserDB GetById(string id)
        {
            return _context.Users.SingleOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<UserDB> GetByIdAsync(string id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveAll()
        {
            _context.Users.RemoveRange(_context.Users);
        }

        public void RemoveById(string id)
        {
            var user = _context.Bookmarks.SingleOrDefault(u => u.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _context.Bookmarks.Remove(user);
        }


        //public IEnumerable<BookmarkDB> GetBookmarksByUserId(string id)
        //{
        //    return _context.Bookmarks.Where(i => i.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        //}

        //public async Task<IEnumerable<BookmarkDB>> GetBookmarksByUserIdAsync(string id)
        //{
        //    return await _context.Bookmarks.Where(i => i.CourseDBId.Equals(id, StringComparison.OrdinalIgnoreCase)).ToListAsync().ConfigureAwait(false);
        //}

        public void Dispose()
        {
            Dispose(true);
        }

        ~UserDBService()
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
