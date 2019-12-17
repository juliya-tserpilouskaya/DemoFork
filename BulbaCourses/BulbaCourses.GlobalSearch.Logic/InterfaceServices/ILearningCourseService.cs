using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Logic.Models;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ILearningCourseService
    {
        IEnumerable<LearningCourse> GetAllCourses();
        LearningCourse GetById(string id);
        IEnumerable<LearningCourse> GetByCategory(string category);
        IEnumerable<LearningCourse> GetByAuthorId(int id);
        IEnumerable<LearningCourseItem> GetLearningItemsByCourseId(string id);
        IEnumerable<LearningCourse> GetCourseByComplexity(string complexity);
        IEnumerable<LearningCourse> GetCourseByLanguage(string lang);
        IEnumerable<LearningCourse> GetCourseByQuery(string query);
    }
}
