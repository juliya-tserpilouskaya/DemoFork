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
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        public IEnumerable<CourseDB> GetAllCourses()
        {
            return _context.Courses
                .Include(c => c.Items);
        }

        public async Task<IEnumerable<CourseDB>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .Include(c => c.Items)
                .ToListAsync().ConfigureAwait(false);
        }

        public CourseDB GetById(string id)
        {
            return _context.Courses
                .Include(c => c.Items)
                .SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public async Task<CourseDB> GetByIdAsync(string id)
        {
            return await _context.Courses
                .Include(c => c.Items)
                .SingleOrDefaultAsync(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase))
                .ConfigureAwait(false);
        }

        public IEnumerable<CourseDB> GetByCategory(int category)
        {
            return _context.Courses.Where(x => x.CourseCategoryDBId == category);
        }

        public async Task<IEnumerable<CourseDB>> GetByCategoryAsync(int category)
        {
            return await _context.Courses.Where(x => x.CourseCategoryDBId == category).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<CourseDB> GetByAuthorId(int id)
        {
            return _context.Courses
                .Include(c => c.Items)
                .Where(course => course.AuthorDBId == id);
        }

        public async Task<IEnumerable<CourseDB>> GetByAuthorIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Items)
                .Where(course => course.AuthorDBId == id)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public IEnumerable<CourseItemDB> GetLearningItemsByCourseId(string id)
        {
            return _context.CourseItems.Where(c => c.CourseDBId.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<CourseItemDB>> GetLearningItemsByCourseIdAsync(string id)
        {
            return await _context.CourseItems.Where(c => c.CourseDBId.Equals(id,
                StringComparison.OrdinalIgnoreCase)).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<CourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.Courses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public async Task<IEnumerable<CourseDB>> GetCourseByComplexityAsync(string complexity)
        {
            return await _context.Courses.Where(course => course.Complexity.ToString().Equals(complexity)).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<CourseDB> GetCourseByLanguage(string lang)
        {
            return _context.Courses.Where(course => course.Language.Contains(lang));
        }

        public async Task<IEnumerable<CourseDB>> GetCourseByLanguageAsync(string lang)
        {
            return await _context.Courses.Where(course => course.Language.Contains(lang)).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<CourseDB> GetCourseByQuery(string query)
        {
            return _context.Courses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }

        public Task<IEnumerable<CourseDB>> GetCourseByQueryAsync(string query)
        {
            throw new NotImplementedException();
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
