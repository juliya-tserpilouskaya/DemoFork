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
        Task<IEnumerable<CourseDB>> GetAllCoursesAsync();
        CourseDB GetById(string id);
        Task<CourseDB> GetByIdAsync(string id);
        IEnumerable<CourseDB> GetByCategory(int category);
        Task<IEnumerable<CourseDB>> GetByCategoryAsync(int catefory);
        IEnumerable<CourseDB> GetByAuthorId(int id);
        Task<IEnumerable<CourseDB>> GetByAuthorIdAsync(int id);
        IEnumerable<CourseItemDB> GetLearningItemsByCourseId(string id);
        Task<IEnumerable<CourseItemDB>> GetLearningItemsByCourseIdAsync(string id);
        IEnumerable<CourseDB> GetCourseByComplexity(string complexity);
        Task<IEnumerable<CourseDB>> GetCourseByComplexityAsync(string complexity);
        IEnumerable<CourseDB> GetCourseByLanguage(string lang);
        Task<IEnumerable<CourseDB>> GetCourseByLanguageAsync(string lang);
        IEnumerable<CourseDB> GetCourseByQuery(string query);
        Task<IEnumerable<CourseDB>> GetCourseByQueryAsync(string query);
        CourseDB Update(CourseDB course);
        CourseDB Add(CourseDB course);
        bool DeleteById(string id);
    }
}
