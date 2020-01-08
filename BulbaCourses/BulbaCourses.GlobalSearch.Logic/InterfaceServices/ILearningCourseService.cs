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
        Task<IEnumerable<LearningCourseDTO>> GetAllCoursesAsync();
        LearningCourseDTO GetById(string id);
        Task<LearningCourseDTO> GetByIdAsync(string id);
        IEnumerable<LearningCourseDTO> GetByCategory(int category);
        Task<IEnumerable<LearningCourseDTO>> GetByCategoryAsync(int category);
        IEnumerable<LearningCourseDTO> GetByAuthorId(int id);
        Task<IEnumerable<LearningCourseDTO>> GetByAuthorIdAsync(int id);
        IEnumerable<LearningCourseItemDTO> GetLearningItemsByCourseId(string id);
        Task<IEnumerable<LearningCourseItemDTO>> GetLearningItemsByCourseIdAsync(string id);
        IEnumerable<LearningCourseDTO> GetCourseByComplexity(string complexity);
        Task<IEnumerable<LearningCourseDTO>> GetCourseByComplexityAsync(string complexity);
        IEnumerable<LearningCourseDTO> GetCourseByLanguage(string lang);
        Task<IEnumerable<LearningCourseDTO>> GetCourseByLanguageAsync(string lang);
        LearningCourseDTO Update(LearningCourseDTO course);
        LearningCourseDTO Add(LearningCourseDTO course);
        bool DeleteById(string id);
    }
}
