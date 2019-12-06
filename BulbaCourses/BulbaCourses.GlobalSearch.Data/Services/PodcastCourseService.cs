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
    class PodcastCourseService : IPodcastCourseService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
        }

        public IEnumerable<PodcastCourseDB> GetAllCourses()
        {
            return _context.PodcastCourses;
        }

        public PodcastCourseDB GetById(string id)
        {
            return _context.PodcastCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<PodcastCourseDB> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PodcastCourseDB> GetByAuthorId(int id)
        {
            return _context.PodcastCourses.Where(course => course.AuthorId == id);
        }

        public IEnumerable<PodcastDB> GetLearningItemsByCourseId(string id)
        {
            return _context.PodcastCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public IEnumerable<PodcastCourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.PodcastCourses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public IEnumerable<PodcastCourseDB> GetCourseByLanguage(string lang)
        {
            return _context.PodcastCourses.Where(course => course.Language.Contains(lang));
        }

        public IEnumerable<PodcastCourseDB> GetCourseByQuery(string query)
        {
            return _context.PodcastCourses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }

        ~PodcastCourseService()
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
