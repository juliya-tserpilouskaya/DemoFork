using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;
using System.Threading.Tasks;
using Presentations.Logic.Models;

namespace Presentations.Logic.Interfaces
{
    public interface ICoursesService : IDisposable
    {
        /// <summary>
        /// Map CourseAdd_DTO to CourseDB, passes to Add DB-method the CourseDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Course>> AddCourseAsync(CourseAdd_DTO model);

        /// <summary>
        /// Map CourseDB to Course, passes to GetByIdAsync DB-method the id for getting course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Course> GetCourseByIdAsync(string id);

        /// <summary>
        /// Map CourseDB to Course, get all courses from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Course>> GetAllCoursesAsync();

        /// <summary>
        /// Map Course to CourseDB, passes to Update DB-method the CourseDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Course>> UpdateCourseAsync(Course model);

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion CourseDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteCourseByIdAsync(string id);

        /// <summary>
        /// Checks exist the same title in the database or not
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> ExistCourseAsync(string title);

        /// <summary>
        /// Get the presentations from the course by course id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Presentation>> GetAllPresentationsFromCourseAsync(string id);
    }
}
