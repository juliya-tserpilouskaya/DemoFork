using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services
{
    class ExcerciseCourseService : IExcerciseCourseService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
        }

        public IEnumerable<ExcerciseCourseDB> GetAllCourses()
        {
            return _context.ExcerciseCourses;
        }

        public ExcerciseCourseDB GetById(string id)
        {
            return _context.ExcerciseCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<ExcerciseCourseDB> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExcerciseCourseDB> GetByAuthorId(int id)
        {
            return _context.ExcerciseCourses.Where(course => course.AuthorId == id);
        }

        public IEnumerable<ExcerciseDB> GetLearningItemsByCourseId(string id)
        {
            return _context.ExcerciseCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public IEnumerable<ExcerciseCourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.ExcerciseCourses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public IEnumerable<ExcerciseCourseDB> GetCourseByLanguage(string lang)
        {
            return _context.ExcerciseCourses.Where(course => course.Language.Contains(lang));
        }

        public IEnumerable<ExcerciseCourseDB> GetCourseByQuery(string query)
        {
            return _context.ExcerciseCourses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }

        ~ExcerciseCourseService()
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
