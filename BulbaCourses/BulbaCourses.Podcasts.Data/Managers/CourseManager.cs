using BulbaCourses.Podcasts.Data.Interfaces;
using BulbaCourses.Podcasts.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Data.Managers
{
    class CourseManager : IManager<CourseDb>
    {

        protected readonly PodcastsContext dbContext;
        private bool _isDisposed = false;

        public CourseManager(PodcastsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CourseDb> Add(CourseDb courseDb)
        {
            dbContext.Courses.Add(courseDb);
            await dbContext.SaveChangesAsync();
            return await Task.FromResult<CourseDb>(courseDb);
        }
        public IEnumerable<CourseDb> GetAll()
        {
            throw new NotImplementedException();
        }
        public CourseDb GetById(string id)
        {
            throw new NotImplementedException();
        }
        public CourseDb Remove(CourseDb courseDb)
        {
            throw new NotImplementedException();
        }
        public CourseDb Update(CourseDb courseDb)
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
