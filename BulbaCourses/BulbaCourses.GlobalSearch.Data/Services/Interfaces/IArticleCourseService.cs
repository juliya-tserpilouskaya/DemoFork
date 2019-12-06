using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface IArticleCourseService
    {
        IEnumerable<ArticleCourseDB> GetAllCourses();
        ArticleCourseDB GetById(string id);
        IEnumerable<ArticleCourseDB> GetByCategory(string category);
        IEnumerable<ArticleCourseDB> GetByAuthorId(int id);
        IEnumerable<ArticleDB> GetLearningItemsByCourseId(string id);
        IEnumerable<ArticleCourseDB> GetCourseByComplexity(string complexity);
        IEnumerable<ArticleCourseDB> GetCourseByLanguage(string lang);
        IEnumerable<ArticleCourseDB> GetCourseByQuery(string query);
    }
}
