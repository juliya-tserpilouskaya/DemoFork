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
    class ArticleCourseService : IArticleCourseService
    {
        private GlobalSearchContext _context = new GlobalSearchContext();

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
        }

        public IEnumerable<ArticleCourseDB> GetAllCourses()
        {
            return _context.ArticleCourses;
        }

        public ArticleCourseDB GetById(string id)
        {
            return _context.ArticleCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<ArticleCourseDB> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleCourseDB> GetByAuthorId(int id)
        {
            return _context.ArticleCourses.Where(course => course.AuthorId == id);
        }

        public IEnumerable<ArticleDB> GetLearningItemsByCourseId(string id)
        {
            return _context.ArticleCourses.SingleOrDefault(c => c.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase)).Items;
        }

        public IEnumerable<ArticleCourseDB> GetCourseByComplexity(string complexity)
        {
            return _context.ArticleCourses.Where(course => course.Complexity.ToString().Equals(complexity));
        }

        public IEnumerable<ArticleCourseDB> GetCourseByLanguage(string lang)
        {
            return _context.ArticleCourses.Where(course => course.Language.Contains(lang));
        }

        public IEnumerable<ArticleCourseDB> GetCourseByQuery(string query)
        {
            return _context.ArticleCourses.Where(course => course.Description.ToLower().Contains(query.ToLower()));
        }

        ~ArticleCourseService()
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
