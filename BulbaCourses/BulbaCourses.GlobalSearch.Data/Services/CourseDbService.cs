using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services
{
    public class CourseDbService : ICourseDbService
    {
        private GlobalSearchContext _context;

        private bool _isDisposed;

        public CourseDbService()
        {
            _context = new GlobalSearchContext();
        }

        public CourseDbService(GlobalSearchContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all stored courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetAllCourses()
        {
            return _context.Courses
                .Include(c => c.Items);
        }

        /// <summary>
        /// Returns all stored courses asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Items)
                .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course by id
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public CourseDB GetById(string id)
        {
            return _context.Courses
                .Include(c => c.Items)
                .SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns learning course by id asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public async Task<CourseDB> GetByIdAsync(string id)
        {
            return await _context.Courses
                .Include(c => c.Items)
                .SingleOrDefaultAsync(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase))
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course by category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetByCategory(int category)
        {
            return _context.Courses.Where(x => x.CourseCategoryDBId == category);
        }

        /// <summary>
        /// Returns learning course by category asynchronously
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetByCategoryAsync(int category)
        {
            return await _context.Courses.Where(x => x.CourseCategoryDBId == category).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course by author
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetByAuthorId(int id)
        {
            return _context.Courses
                .Include(c => c.Items)
                .Where(course => course.AuthorDBId == id);
        }

        /// <summary>
        /// Returns learning course by author asynchronously
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetByAuthorIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Items)
                .Where(course => course.AuthorDBId == id)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course materials
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public IEnumerable<CourseItemDB> GetLearningItemsByCourseId(string id)
        {
            return _context.CourseItems.Where(c => c.CourseDBId.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns learning course materials asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseItemDB>> GetLearningItemsByCourseIdAsync(string id)
        {
            return await _context.CourseItems.Where(c => c.CourseDBId.Equals(id,
                StringComparison.OrdinalIgnoreCase)).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course by complexity
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.Courses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        /// <summary>
        /// Returns learning course by complexity asynchronously
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetCourseByComplexityAsync(string complexity)
        {
            return await _context.Courses.Where(course => course.Complexity.ToString().Equals(complexity)).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course by language
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetCourseByLanguage(string lang)
        {
            return _context.Courses.Where(course => course.Language.Contains(lang));
        }

        /// <summary>
        /// Returns learning course by language asynchronously
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetCourseByLanguageAsync(string lang)
        {
            return await _context.Courses.Where(course => course.Language.Contains(lang)).ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns course by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetCourseByQuery(string query)
        {
            return _context.Courses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }

        /// <summary>
        /// Returns course by query asynchronously
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<IEnumerable<CourseDB>> GetCourseByQueryAsync(string query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates course data
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public CourseDB Update(CourseDB course)
        {
            CourseDB deletedCourse = _context.Courses
                .SingleOrDefault(p => p.Id.Equals(course.Id, StringComparison.OrdinalIgnoreCase));

            if (deletedCourse != null)
            {
                _context.Courses.Remove(deletedCourse);
                course.Id = Guid.NewGuid().ToString();
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
            else
            {
                return deletedCourse;
            }
            return course;
        }

        /// <summary>
        /// Creates learning course
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public CourseDB Add(CourseDB course)
        {
            course.Id = Guid.NewGuid().ToString();
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        /// <summary>
        /// Deletes course from database
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        public bool DeleteById(string id)
        {
            CourseDB courseToDelete = _context.Courses
                .Include(p => p.Items)
                .SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (courseToDelete != null)
            {
                _context.CourseItems.RemoveRange(courseToDelete.Items.ToArray());
                _context.Courses.Remove(courseToDelete);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~CourseDbService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed)
            {
                return;
            }

            _context.Dispose();
            _isDisposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}
