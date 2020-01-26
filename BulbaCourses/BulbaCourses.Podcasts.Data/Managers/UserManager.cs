using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Web")]
namespace BulbaCourses.Podcasts.Data.Managers
{
    public class UserManager : BaseManager, IManager<UserDb>
    {
        public UserManager(PodcastsContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserDb> AddAsync(UserDb userDb)
        {
            dbContext.Users.Add(userDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false); ;
            return await Task.FromResult(userDb).ConfigureAwait(false);
        }

        public async Task<IEnumerable<UserDb>> GetAllAsync(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                var courseList = await dbContext.Users.AsNoTracking().ToListAsync().ConfigureAwait(false);
                return courseList.AsReadOnly();
            }
            else
            {
                var courseList = await dbContext.Users.AsNoTracking().Where(c => c.Name.Contains(filter)).ToListAsync().ConfigureAwait(false);
                return courseList.AsReadOnly();
            }
        }
        public async Task<UserDb> GetByIdAsync(string id)
        {
            return await dbContext.Users.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
        }

        public async void RemoveAsync(UserDb userDb)
        {
            if (userDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Comments.RemoveRange(userDb.Comments.AsEnumerable());
            dbContext.Users.Remove(userDb);
            dbContext.Courses.ToList().ForEach(x => x.Author = null);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<UserDb> UpdateAsync(UserDb userDb)
        {
            if (userDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Entry(userDb).State = EntityState.Modified;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(userDb);
        }

        public async Task<bool> ExistIdAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            return await dbContext.Courses.AnyAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
        }

        public async Task<bool> ExistNameAsync(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            return await dbContext.Courses.AnyAsync(c => c.Name.Equals(id)).ConfigureAwait(false);
        }
    }
}