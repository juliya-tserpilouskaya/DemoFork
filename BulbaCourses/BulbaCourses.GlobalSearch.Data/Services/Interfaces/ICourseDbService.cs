using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface ICourseDbService
    {
        /// <summary>
        /// Returns all stored courses
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseDB> GetAllCourses();

        /// <summary>
        /// Returns all stored courses asynchronously
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CourseDB>> GetAllCoursesAsync();

        /// <summary>
        /// Returns learning course by id
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        CourseDB GetById(string id);

        /// <summary>
        /// Returns learning course by id asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        Task<CourseDB> GetByIdAsync(string id);

        /// <summary>
        /// Returns learning course by category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        IEnumerable<CourseDB> GetByCategory(int category);

        /// <summary>
        /// Returns learning course by category asynchronously
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        Task<IEnumerable<CourseDB>> GetByCategoryAsync(int category);

        /// <summary>
        /// Returns learning course by author
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        IEnumerable<CourseDB> GetByAuthorId(int id);

        /// <summary>
        /// Returns learning course by author asynchronously
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        Task<IEnumerable<CourseDB>> GetByAuthorIdAsync(int id);

        /// <summary>
        /// Returns learning course materials
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        IEnumerable<CourseItemDB> GetLearningItemsByCourseId(string id);

        /// <summary>
        /// Returns learning course materials asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        Task<IEnumerable<CourseItemDB>> GetLearningItemsByCourseIdAsync(string id);

        /// <summary>
        /// Returns learning course by complexity
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        IEnumerable<CourseDB> GetCourseByComplexity(string complexity);

        /// <summary>
        /// Returns learning course by complexity asynchronously
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        Task<IEnumerable<CourseDB>> GetCourseByComplexityAsync(string complexity);

        /// <summary>
        /// Returns learning course by language
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        IEnumerable<CourseDB> GetCourseByLanguage(string lang);

        /// <summary>
        /// Returns learning course by language asynchronously
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        Task<IEnumerable<CourseDB>> GetCourseByLanguageAsync(string lang);
        
        /// <summary>
        /// Returns course by query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<CourseDB> GetCourseByQuery(string query);

        /// <summary>
        /// Returns course by query async
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<CourseDB>> GetCourseByQueryAsync(string query);

        /// <summary>
        /// Updates course data
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        CourseDB Update(CourseDB course);

        /// <summary>
        /// Updates course data async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        Task<Result<CourseDB>> UpdateAsync(CourseDB course);


        /// <summary>
        /// Creates learning course
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        CourseDB Add(CourseDB course);

        /// <summary>
        /// Creates learning course async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        Task<Result<CourseDB>> AddAsync(CourseDB course);


        /// <summary>
        /// Deletes course from database
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        bool DeleteById(string id);

        /// <summary>
        /// Deletes course from database async
        /// </summary>
        /// <param name="id">Course id</param>
        /// <returns></returns>
        Task<Result> DeleteByIdAsync(string id);

    }
}
