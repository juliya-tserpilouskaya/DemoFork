using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {

        public CourseRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(CourseDb course)
        {
            _videoDbContext.Courses.Add(course);
            _videoDbContext.SaveChanges();

        }

        public async Task<CourseDb> AddAsync(CourseDb course)
        {
            _videoDbContext.Courses.Add(course);
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(course);
        }

        public IEnumerable<CourseDb> GetAll()
        {
            var courseList = _videoDbContext.Courses.ToList().AsReadOnly();
            return courseList;

        }

        public async Task<IEnumerable<CourseDb>> GetAllAsync()
        {
            var courseList = await _videoDbContext.Courses.ToListAsync().ConfigureAwait(false);
            return courseList.AsReadOnly();
        }

        public CourseDb GetById(string courseId)
        {
            var course = _videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            return course;

        }

        public async Task<CourseDb> GetByIdAsync(string courseId)
        {
            var course = await _videoDbContext.Courses.SingleOrDefaultAsync(b => b.CourseId.Equals(courseId)).ConfigureAwait(false);
            return course;
        }

        public void Remove(CourseDb course)
        {
            _videoDbContext.Courses.Remove(course);
            _videoDbContext.SaveChanges();

        }

        public async Task RemoveAsync(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            _videoDbContext.Courses.Remove(course);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task RemoveAsyncById(string courseId)
        {
            var course = _videoDbContext.Courses.SingleOrDefault(c => c.CourseId.Equals(courseId));
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            _videoDbContext.Courses.Remove(course);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            _videoDbContext.Entry(course).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        public async Task<CourseDb> UpdateAsync(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            _videoDbContext.Entry(course).State = EntityState.Modified;
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(course);
        }

        public async Task<bool> IsNameExistAsync(string courseName)
        {
            return await _videoDbContext.Courses.AnyAsync(c => c.Name.Equals(courseName)).ConfigureAwait(false);
        }
    }
}
