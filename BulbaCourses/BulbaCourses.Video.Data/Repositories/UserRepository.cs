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

        public void Add(UserDb user)
        {
            _videoDbContext.Users.Add(user);
            _videoDbContext.SaveChanges();
        }

        public UserDb GetById(string id)
        {
            var user = _videoDbContext.Users.FirstOrDefault(b => b.UserId.Equals(id));
            return user;
        }

        public IEnumerable<UserDb> GetAll()
        {
            var userList = _videoDbContext.Users.ToList().AsReadOnly();
            return userList;
        }

        public void Remove(UserDb user)
        {
            _videoDbContext.Users.Remove(user);
            _videoDbContext.SaveChanges();
        }

        public void Update(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Entry(user).State = EntityState.Modified;
            _videoDbContext.SaveChanges();
        }

        public async Task<UserDb> AddAsync(UserDb user)
        {
            _videoDbContext.Users.Add(user);
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<UserDb>> GetAllAsync()
        {
            var userList = await _videoDbContext.Users.ToListAsync().ConfigureAwait(false);
            return userList.AsReadOnly();
        }

        public async Task<UserDb> GetByIdAsync(string userId)
        {
            var user = await _videoDbContext.Users.SingleOrDefaultAsync(b => b.UserId.Equals(userId)).ConfigureAwait(false);
            return user;
        }

        public async Task RemoveAsync(UserDb user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            _videoDbContext.Users.Remove(user);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

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
    }
}
