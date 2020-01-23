using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using BulbaComments.Podcasts.Data.Managers;
[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Web")]
namespace BulbaCourses.Podcasts.Data.Managers
{
    public class CourseManager : BaseManager, IManager<CourseDb>
    {
        public CourseManager(PodcastsContext dbContext) : base(dbContext)
        {
        }

        public async Task<CourseDb> AddAsync(CourseDb courseDb)
        {
            dbContext.Courses.Add(courseDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false); ;
            return await Task.FromResult(courseDb).ConfigureAwait(false);
        }

        public async Task<IEnumerable<CourseDb>> GetAllAsync(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                var courseList = await dbContext.Courses.AsNoTracking().ToListAsync().ConfigureAwait(false);
                return courseList.AsReadOnly();
            }
            else
            {
                var courseList = await dbContext.Courses.AsNoTracking().Where(c => c.Name.Contains(filter)).ToListAsync().ConfigureAwait(false);
                return courseList.AsReadOnly();
            }
        }

        public async Task<CourseDb> GetByIdAsync(string id)
        {
            return await dbContext.Courses.SingleOrDefaultAsync(b => b.Id.Equals(id)).ConfigureAwait(false);
        }

        public async void RemoveAsync(CourseDb courseDb)
        {
            if (courseDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Audios.RemoveRange(courseDb.Audios.AsEnumerable());
            dbContext.Comments.RemoveRange(courseDb.Comments.AsEnumerable());
            List<CommentDb> appended = new List<CommentDb>();
            dbContext.Courses.Remove(courseDb);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<CourseDb> UpdateAsync(CourseDb courseDb)
        {
            if (courseDb == null)
            {
                throw new ArgumentNullException();
            }
            dbContext.Entry(courseDb).State = EntityState.Modified;
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(courseDb);
        }

        public async Task<bool> IsExistAsync(string name)
        {
            return await dbContext.Courses.AnyAsync(c => c.Name.Equals(name)).ConfigureAwait(false);
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
