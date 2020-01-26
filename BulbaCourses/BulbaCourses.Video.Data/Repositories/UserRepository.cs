using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        /// <summary>
        /// Create a new user in repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Add(UserDb user)
        {
            _videoDbContext.Users.Add(user);
            _videoDbContext.SaveChanges();
        }

        /// <summary>
        /// Shows user details by id in repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDb GetById(string id)
        {
            var user = _videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(id));
            return user;
        }

        /// <summary>
        /// Gets all users in repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDb> GetAll()
        {
            var userList = _videoDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        /// <summary>
        /// Remove user in repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Remove(UserDb user)
        {
            _videoDbContext.Users.Remove(user);
            _videoDbContext.SaveChanges();
        }

        /// <summary>
        /// Update user in repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Update(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Entry(user).State = EntityState.Modified;
            _videoDbContext.SaveChanges();
        }

        /// <summary>
        /// Create a new user in repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDb> AddAsync(UserDb user)
        {
            _videoDbContext.Users.Add(user);
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(user);
        }

        /// <summary>
        /// Gets all users in repository.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDb>> GetAllAsync()
        {
            var userList = await _videoDbContext.Users.ToListAsync().ConfigureAwait(false);
            return userList.AsReadOnly();
        }

        /// <summary>
        /// Shows user details by id in repository.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDb> GetByIdAsync(string userId)
        {
            var user = await _videoDbContext.Users.SingleOrDefaultAsync(b => b.UserId.Equals(userId)).ConfigureAwait(false);
            return user;
        }

        /// <summary>
        /// Remove user in repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task RemoveAsync(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Users.Remove(user);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Remove user by id in repository.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task RemoveAsyncById(string userId)
        {
            var user = _videoDbContext.Users.SingleOrDefault(b => b.UserId.Equals(userId));
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Users.Remove(user);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Update user in repository.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserDb> UpdateAsync(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Entry(user).State = EntityState.Modified;
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(user);
        }

        /// <summary>
        /// Create a new user transaction in repository.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<TransactionDb> AddTransaction(TransactionDb transaction)
        {
            _videoDbContext.Transactions.Add(transaction);
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(transaction);
        }
    }
}
