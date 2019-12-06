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
    class VideoCourseService : IVideoCourseService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        public IEnumerable<VideoCourseDB> GetAllCourses()
        {
            return _context.VideoCourses;
        }

        public VideoCourseDB GetById(string id)
        {
            return _context.VideoCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<VideoCourseDB> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VideoCourseDB> GetByAuthorId(int id)
        {
            return _context.VideoCourses.Where(course => course.AuthorId == id);
        }

        public IEnumerable<VideoDB> GetLearningItemsByCourseId(string id)
        {
            return _context.VideoCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public IEnumerable<VideoCourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.VideoCourses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public IEnumerable<VideoCourseDB> GetCourseByLanguage(string lang)
        {
            return _context.VideoCourses.Where(course => course.Language.Contains(lang));
        }

        public IEnumerable<VideoCourseDB> GetCourseByQuery(string query)
        {
            return _context.VideoCourses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }
        public void Dispose()
        {
            Dispose(true);
        }

        ~VideoCourseService()
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
