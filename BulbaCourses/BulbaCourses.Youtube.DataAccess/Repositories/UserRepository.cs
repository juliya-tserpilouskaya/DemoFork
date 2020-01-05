using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private YoutubeContext _context;
        private bool _isDisposed = false;

        public UserRepository(YoutubeContext ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Save User 
        /// </summary>
        /// <param name="user"></param>
        public UserDb Save(UserDb user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        /// <summary>
        /// Get all Users 
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public IEnumerable<UserDb> GetAll()
        {
            return _context.Users.ToList().AsReadOnly();
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserDb GetById(int? userId)
        {
            return _context.Users.SingleOrDefault(s => s.Id == userId);
        }

        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteById(int? userId)
        {
            var delUser = _context.Users.SingleOrDefault(s => s.Id == userId);
            if (delUser != null)
            {
                _context.Users.Remove(delUser);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Check if User exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Exists(UserDb user)
        {
            return _context.Users.Any(u => u.Id == user.Id && u.Login == user.Login);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;
            _context.Dispose();
            _isDisposed = true;

            if (flag)
                GC.SuppressFinalize(this);
        }
    }
}
