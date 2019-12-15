using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
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
            return _context.Courses;
        }

        public CourseDB GetById(string id)
        {
            return _context.Courses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<CourseDB> GetByCategory(int category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDB> GetByAuthorId(int id)
        {
            return _context.Courses.Where(course => course.AuthorDBId == id);
        }

        public IEnumerable<CourseItemDB> GetLearningItemsByCourseId(string id)
        {
            return _context.Courses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public IEnumerable<CourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.Courses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public IEnumerable<CourseDB> GetCourseByLanguage(string lang)
        {
            return _context.Courses.Where(course => course.Language.Contains(lang));
        }

        public IEnumerable<CourseDB> GetCourseByQuery(string query)
        {
            return _context.Courses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
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
