using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Infrastructure.Models;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.Models;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ILearningCourseService
    {
        /// <summary>
        /// Returns all stored courses
        /// </summary>
        /// <returns></returns>
        IEnumerable<LearningCourseDTO> GetAllCourses();

        /// <summary>
        /// Returns all stored courses asynchronously
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LearningCourseDTO>> GetAllCoursesAsync();

        /// <summary>
        /// Returns learning course by id
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        LearningCourseDTO GetById(string id);

        /// <summary>
        /// Returns learning course by id asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        Task<LearningCourseDTO> GetByIdAsync(string id);

        /// <summary>
        /// Returns learning course by category
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        IEnumerable<LearningCourseDTO> GetByCategory(int category);

        /// <summary>
        /// Returns learning course by category asynchronously
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns></returns>
        Task<IEnumerable<LearningCourseDTO>> GetByCategoryAsync(int category);

        /// <summary>
        /// Returns learning course by author
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        IEnumerable<LearningCourseDTO> GetByAuthorId(int id);

        /// <summary>
        /// Returns learning course by author asynchronously
        /// </summary>
        /// <param name="id"> Author id</param>
        /// <returns></returns>
        Task<IEnumerable<LearningCourseDTO>> GetByAuthorIdAsync(int id);

        /// <summary>
        /// Returns learning course materials
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        IEnumerable<LearningCourseItemDTO> GetLearningItemsByCourseId(string id);


        /// <summary>
        /// Returns learning course materials asynchronously
        /// </summary>
        /// <param name="id">Learning course id</param>
        /// <returns></returns>
        Task<IEnumerable<LearningCourseItemDTO>> GetLearningItemsByCourseIdAsync(string id);

        /// <summary>
        /// Returns learning course by complexity
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        IEnumerable<LearningCourseDTO> GetCourseByComplexity(string complexity);

        /// <summary>
        /// Returns learning course by complexity asynchronously
        /// </summary>
        /// <param name="complexity">Complexity</param>
        /// <returns></returns>
        Task<IEnumerable<LearningCourseDTO>> GetCourseByComplexityAsync(string complexity);

        /// <summary>
        /// Returns learning course by language
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        IEnumerable<LearningCourseDTO> GetCourseByLanguage(string lang);

        /// <summary>
        /// Returns learning course by language asynchronously
        /// </summary>
        /// <param name="lang">Language</param>
        /// <returns></returns>
        Task<IEnumerable<LearningCourseDTO>> GetCourseByLanguageAsync(string lang);

        /// <summary>
        /// Updates course data
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        LearningCourseDTO Update(LearningCourseDTO course);

        /// <summary>
        /// Updates course data async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        Task<Result<LearningCourseDTO>> UpdateAsync(LearningCourseDTO course);


        /// <summary>
        /// Creates learning course
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        LearningCourseDTO Add(LearningCourseDTO course);

        /// <summary>
        /// Creates learning course async
        /// </summary>
        /// <param name="course">Learning course</param>
        /// <returns></returns>
        Task<Result<LearningCourseDTO>> AddAsync(LearningCourseDTO course);


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
