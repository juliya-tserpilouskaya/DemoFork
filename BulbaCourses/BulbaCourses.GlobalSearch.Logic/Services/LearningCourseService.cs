using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    public class LearningCourseService : ILearningCourseService
    {
        public IEnumerable<LearningCourse> GetAllCourses()
        {
            return LearningCourseStorage.GetAllCourses();
        }

        public LearningCourse GetById(string id)
        {
            return LearningCourseStorage.GetById(id);
        }

        public IEnumerable<LearningCourse> GetByCategory(string category)
        {
            return LearningCourseStorage.GetByCategory(category);
        }

        public IEnumerable<LearningCourse> GetByAuthorId(int id)
        {
            return LearningCourseStorage.GetByAuthorId(id);
        }

        public IEnumerable<LearningCourseItem> GetLearningItemsByCourseId(string id)
        {
            return LearningCourseStorage.GetLearningItemsByCourseId(id);
        }

        public IEnumerable<LearningCourse> GetCourseByComplexity(string complexity)
        {
            return LearningCourseStorage.GetCourseByComplexity(complexity);
        }

        public IEnumerable<LearningCourse> GetCourseByLanguage(string lang)
        {
            return LearningCourseStorage.GetCourseByLanguage(lang);
        }

        public IEnumerable<LearningCourse> GetCourseByQuery(string query)
        {
            return LearningCourseStorage.GetCourseByQuery(query);
        }
    }
}
