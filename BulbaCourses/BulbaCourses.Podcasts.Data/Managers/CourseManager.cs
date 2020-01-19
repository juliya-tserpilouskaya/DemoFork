using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BulbaCourses.Podcasts.Data.Managers
{
    class CourseManager : BaseManager, IManager<CourseDb>
    {
        public CourseManager(PodcastsContext dbContext) : base(dbContext)
        {
        }

        public async Task<CourseDb> Add(CourseDb courseDb)
        {
            dbContext.Courses.Add(courseDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false); ;
            return await Task.FromResult(courseDb).ConfigureAwait(false);
        }
        public async Task<IEnumerable<CourseDb>> GetAll()
        {
            var courseList = await dbContext.Courses.ToListAsync().ConfigureAwait(false);
            return courseList.AsReadOnly();
        }
        public async Task<CourseDb> GetById(string id)
        {
            return await dbContext.Courses.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
        }
        public async Task<CourseDb> Remove(CourseDb courseDb)
        {
            if (courseDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Courses.Remove(courseDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return null;
        }
        public async Task<CourseDb> Update(CourseDb courseDb)
        {
            if (courseDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Entry(courseDb).State = EntityState.Modified;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(courseDb);
        }
        public async Task<bool> IsExist(string name)
        {
            return await dbContext.Courses.AnyAsync(c => c.Name.Equals(name)).ConfigureAwait(false);
        }
    }
}
