using BulbaCourses.GlobalSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface ICourseDbService
    {
        IEnumerable<CourseDB> GetAllCourses();
        CourseDB GetById(string id);
        IEnumerable<CourseDB> GetByCategory(int category);
        IEnumerable<CourseDB> GetByAuthorId(int id);
        IEnumerable<CourseItemDB> GetLearningItemsByCourseId(string id);
        IEnumerable<CourseDB> GetCourseByComplexity(string complexity);
        IEnumerable<CourseDB> GetCourseByLanguage(string lang);
        IEnumerable<CourseDB> GetCourseByQuery(string query);
    }
}
