using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaCourses.Podcasts.Data;

class CourseManager : BaseManager, IManager<UserDb>
{
    public CourseManager(PodcastsContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserDb> AddAsync(UserDb userDb)
    {
        dbContext.Users.Add(userDb);
        await dbContext.SaveChangesAsync().ConfigureAwait(false); ;
        return await Task.FromResult(userDb).ConfigureAwait(false);
    }
    public async Task<IEnumerable<UserDb>> GetAllAsync()
    {
        var courseList = await dbContext.Users.ToListAsync().ConfigureAwait(false);
        return courseList.AsReadOnly();
    }
    public async Task<UserDb> GetByIdAsync(string id)
    {
        return await dbContext.Users.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
    }
    public async Task<UserDb> RemoveAsync(UserDb userDb)
    {
        if (userDb == null)
        {
            throw new ArgumentNullException();
        }
        dbContext.Comments.RemoveRange(userDb.Comments.AsEnumerable());
        dbContext.Users.Remove(userDb);
        dbContext.Courses.ToList().ForEach(x => x.Author = null);
        await dbContext.SaveChangesAsync().ConfigureAwait(false);
        return null;
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
    public async Task<bool> IsExistAsync(string name)
    {
        return await dbContext.Users.AnyAsync(c => c.Name.Equals(name)).ConfigureAwait(false);
    }

    public async Task<bool> ExistAsync(string name)
    {
        return await dbContext.Courses.AnyAsync(c => c.Name.Equals(name)).ConfigureAwait(false);
    }
}