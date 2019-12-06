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
    class TestCourseService : ITestCourseService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
        }

        public IEnumerable<TestCourseDB> GetAllCourses()
        {
            return _context.TestCourses;
        }

        public TestCourseDB GetById(string id)
        {
            return _context.TestCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<TestCourseDB> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestCourseDB> GetByAuthorId(int id)
        {
            return _context.TestCourses.Where(course => course.AuthorId == id);
        }

        public IEnumerable<TestDB> GetLearningItemsByCourseId(string id)
        {
            return _context.TestCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public IEnumerable<TestCourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.TestCourses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public IEnumerable<TestCourseDB> GetCourseByLanguage(string lang)
        {
            return _context.TestCourses.Where(course => course.Language.Contains(lang));
        }

        public IEnumerable<TestCourseDB> GetCourseByQuery(string query)
        {
            return _context.TestCourses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }

        ~TestCourseService()
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
