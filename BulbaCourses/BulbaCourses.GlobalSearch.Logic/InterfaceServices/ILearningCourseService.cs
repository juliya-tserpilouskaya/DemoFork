using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.Models;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ILearningCourseService
    {
        IEnumerable<LearningCourseDTO> GetAllCourses();
        LearningCourseDTO GetById(string id);
        IEnumerable<LearningCourseDTO> GetByCategory(int category);
        IEnumerable<LearningCourseDTO> GetByAuthorId(int id);
        IEnumerable<LearningCourseItemDTO> GetLearningItemsByCourseId(string id);
        IEnumerable<LearningCourseDTO> GetCourseByComplexity(string complexity);
        IEnumerable<LearningCourseDTO> GetCourseByLanguage(string lang);

    }
}
