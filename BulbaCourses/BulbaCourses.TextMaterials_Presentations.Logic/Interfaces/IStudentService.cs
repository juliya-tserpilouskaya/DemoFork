using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;
using System.Threading.Tasks;
using Presentations.Logic.Models;

namespace Presentations.Logic.Interfaces
{
    public interface IStudentService : IDisposable
    {
        /// <summary>
        /// Map UserAdd_DTO to StudentDB, passes to Add DB-method the StudentDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Student>> AddStudentAsync(UserAdd_DTO model);

        /// <summary>
        /// Map StudentDB to Student, passes to GetByIdAsync DB-method the id for getting student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Student> GetStudentByIdAsync(string id);

        /// <summary>
        /// Map StudentDB to Student, get all students from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        /// <summary>
        /// Map Student to StudentDB, passes to Update DB-method the StudentDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Student>> UpdateStudentAsync(Student model);

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion StudentDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteStudentByIdAsync(string id);

        Task<bool> ExistStudentAsync(string userIdIdentity);

        /// <summary>
        /// Add favorite presentation to the collection of favorite
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        Task<Result> AddLovedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Delete favorite presentation from the collection of favorite
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        Task<Result> DeleteLovedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Gel all presentations from the collection of favorite by student id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Presentation>> GetAllLovedPresentationAsync(string id);

        /// <summary>
        /// Add watched presentation to the collection of watched
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        Task<Result> AddWatchedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Delete watched presentation from the collection of watched
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        /// <returns></returns>
        Task<Result> DeleteWatchedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Gel all presentations from the collection of watched by student id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Presentation>> GetAllWatchedPresentationAsync(string id);

        /// <summary>
        /// Update the payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hasPayment"></param>
        /// <returns></returns>
        Task<Result> UpdateIsPaidAsync(string id, bool hasPayment);

        /// <summary>
        /// Gel all feedbacks of this student by student id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Feedback>> GetAllFeedbacksFromStudentAsync(string id);

    }
}
