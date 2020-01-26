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
    /// <summary>
    /// Provides a mechanism for working course repository.
    /// </summary>
    public class CourseRepository : BaseRepository, ICourseRepository
    {

        public CourseRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        /// <summary>
        /// Create new course in repository.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public void Add(CourseDb course)
        {
            _videoDbContext.Courses.Add(course);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Create new course in repository.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task<CourseDb> AddAsync(CourseDb course)
        {
            _videoDbContext.Courses.Add(course);
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(course);
        }

        /// <summary>
        /// Gets all courses in repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CourseDb> GetAll()
        {
            var courseList = _videoDbContext.Courses.ToList().AsReadOnly();
            return courseList;

        }

        /// <summary>
        /// Gets all courses in repository.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDb>> GetAllAsync()
        {
            var courseList = await _videoDbContext.Courses.ToListAsync().ConfigureAwait(false);
            return courseList.AsReadOnly();
        }

        /// <summary>
        /// Gets all videos from course by id in repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<VideoMaterialDb>> GetCoursesAsync(string id)
        {
            var videos = await _videoDbContext.Courses.Where(c => c.CourseId.Equals(id))?.SelectMany(c => c.Videos).ToListAsync();
            return videos.AsReadOnly(); ;
        }

        /// <summary>
        /// Gets all author courses by author in repository.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDb>> GetByAuthorAsync(AuthorDb author)
        {
            var courses = await _videoDbContext.Authors.Where(c => c.AuthorId == author.AuthorId)?.SelectMany(c => c.AuthorCourses).ToListAsync();
            //var courses = await _videoDbContext.Tags.Where(c => c.TagId == tag.TagId)?.SelectMany(c => c.Courses).ToListAsync();
            return courses.AsReadOnly(); ;
        }

        /// <summary>
        /// Shows course details by id in repository.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public CourseDb GetById(string courseId)
        {
            var course = _videoDbContext.Courses.FirstOrDefault(b => b.CourseId.Equals(courseId));
            return course;

        }

        /// <summary>
        /// Shows course details by id in repository.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<CourseDb> GetByIdAsync(string courseId)
        {
            var course = await _videoDbContext.Courses.SingleOrDefaultAsync(b => b.CourseId.Equals(courseId)).ConfigureAwait(false);
            return course;
        }

        /// <summary>
        /// Remove course in repository.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public void Remove(CourseDb course)
        {
            _videoDbContext.Courses.Remove(course);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Remove course in repository.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task RemoveAsync(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            _videoDbContext.Courses.Remove(course);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Remove course by id in repository.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update course in repository.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public void Update(CourseDb course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }
            _videoDbContext.Entry(course).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Update course in repository.
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check if course exists with this Name.
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public async Task<bool> IsNameExistAsync(string courseName)
        {
            return await _videoDbContext.Courses.AnyAsync(c => c.Name.Equals(courseName)).ConfigureAwait(false);
        }
    }
}
