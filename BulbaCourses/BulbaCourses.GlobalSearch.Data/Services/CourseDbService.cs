using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
            this._context = new GlobalSearchContext();
        }

        public CourseDbService(GlobalSearchContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Returns all stored courses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CourseDB> GetAllCourses()
        {
            var query = from course in _context.Courses select course;
            return query.Include(c => c.Items).AsNoTracking();
            //return _context.Courses
            //    .Include(c => c.Items);
        }

        /// <summary>
        /// Returns all stored courses asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetAllCoursesAsync()
        {
            var query = from course in _context.Courses select course;
            return await query.Include(c => c.Items).AsNoTracking().ToListAsync().ConfigureAwait(false);

            //return await _context.Courses
            //    .Include(c => c.Items)
            //    .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Returns learning course by id
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public CourseDB GetById(string id)
        {
            var query = from course in _context.Courses select course;
            return query.Include(c => c.Items)
                .SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));

            //return _context.Courses
            //    .Include(c => c.Items)
            //    .SingleOrDefault(c => c.Id.Equals(id,
            //    StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns learning course by id asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        public async Task<CourseDB> GetByIdAsync(string id)
        {
            var query = from course in _context.Courses select course;
            return await query
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
            var query = from course in _context.Courses select course;
            return query
                .Include(c => c.Items)
                .Where(course => course.AuthorDBId == id).AsNoTracking();
        }

        /// <summary>
        /// Returns learning course by author asynchronously
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetByAuthorIdAsync(int id)
        {

            var query = from course in _context.Courses select course;
            return await query
                .Include(c => c.Items)
                .Where(course => course.AuthorDBId == id)
                .ToListAsync()
                .ConfigureAwait(false);

            //return await _context.Courses
            //    .Include(c => c.Items)
            //    .Where(course => course.AuthorDBId == id)
            //    .ToListAsync()
            //    .ConfigureAwait(false);
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
            var query = from course in _context.Courses select course;
            return query.Where(course => course.Complexity.Equals(complexity,
                StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Returns learning course by complexity asynchronously
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        public async Task<IEnumerable<CourseDB>> GetCourseByComplexityAsync(string complexity)
        {
            return await _context.Courses.Where(course => course.Complexity.ToString()
            .Equals(complexity))
                .ToListAsync()
                .ConfigureAwait(false);
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
            return await _context.Courses
                .Where(course => course.Language
                .Contains(lang))
                .ToListAsync()
                .ConfigureAwait(false);
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
        /// Updates course data async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public async Task<Result<CourseDB>> UpdateAsync(CourseDB course)
        {
            try
            {
                CourseDB deletedCourse = _context.Courses
                    .Include(i => i.Items)
                    .SingleOrDefault(p => p.Id.Equals(course.Id, StringComparison.OrdinalIgnoreCase));

                if (deletedCourse != null)
                {
                    //var items = deletedCourse.Items.ToArray();
                    //if (items != null)
                    //{
                    //    _context.CourseItems.RemoveRange(items);
                    //}
                    //_context.CourseItems.RemoveRange(items);
                    _context.Courses.Remove(deletedCourse);
                    course.Id = Guid.NewGuid().ToString();
                    _context.Courses.Add(course);
                    await _context.SaveChangesAsync();
                    return Result<CourseDB>.Ok(course);
                }
                else
                {
                    return Result<CourseDB>.Fail<CourseDB>($"Course not found."); ;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Course can not be updated. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Course can not be updated. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Invalid SearchCriteria. {e.Message}");
            }
        }

        /// <summary>
        /// Updates course data async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        public async Task<Result<CourseDB>> AddAsync(CourseDB course)
        {
            try
            {
                course.Id = Guid.NewGuid().ToString();
                _context.Courses.Add(course);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseDB>.Ok(course);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Cannot save course. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Cannot save course. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Invalid course. {e.Message}");
            }
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
            var query = from course in _context.Courses select course;
            CourseDB courseToDelete = query
                .Include(p => p.Items)
                .SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (courseToDelete != null)
            {
                var items = courseToDelete.Items.ToArray();
                _context.CourseItems.RemoveRange(items);
                _context.Courses.Remove(courseToDelete);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Deletes course from database
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        public async Task<Result> DeleteByIdAsync(string id)
        {

            var query = from course in _context.Courses select course;
            CourseDB courseToDelete = query
                .Include(p => p.Items)
                .SingleOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            var items = courseToDelete.Items.ToArray();
            try
            {
                _context.CourseItems.RemoveRange(items);
                _context.Courses.Remove(courseToDelete);
                await _context.SaveChangesAsync().ConfigureAwait(false); ;
                return Result<CourseDB>.Ok(courseToDelete);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Course not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<CourseDB>.Fail<CourseDB>($"Course invalid. {e.Message}");
            }
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
