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
            throw new NotImplementedException();
        }
        public async Task<CourseDb> Remove(CourseDb courseDb)
        {
            throw new NotImplementedException();
        }
        public async Task<CourseDb> Update(CourseDb courseDb)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected void Dispose(bool flag)
        {
            if (_isDisposed) return;

            dbContext?.Dispose();
            _isDisposed = true;
            if (flag) GC.SuppressFinalize(this);
        }

        ~CourseManager()
        {
            this.Dispose(false);
        }
    }
}
