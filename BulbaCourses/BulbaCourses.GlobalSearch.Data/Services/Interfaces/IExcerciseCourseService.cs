using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface IExcerciseCourseService
    {
        IEnumerable<ExcerciseCourseDB> GetAllCourses();
        ExcerciseCourseDB GetById(string id);
        IEnumerable<ExcerciseCourseDB> GetByCategory(string category);
        IEnumerable<ExcerciseCourseDB> GetByAuthorId(int id);
        IEnumerable<ExcerciseDB> GetLearningItemsByCourseId(string id);
        IEnumerable<ExcerciseCourseDB> GetCourseByComplexity(string complexity);
        IEnumerable<ExcerciseCourseDB> GetCourseByLanguage(string lang);
        IEnumerable<ExcerciseCourseDB> GetCourseByQuery(string query);
    }
}
