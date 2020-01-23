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

        Task<Result> AddLovedPresentationAsync(string idStudent, string idPresentation);
        Task<Result> DeleteLovedPresentationAsync(string idStudent, string idPresentation);
        Task<IEnumerable<Presentation>> GetAllLovedPresentationAsync(string id);

        Task<Result> AddViewedPresentationAsync(string idStudent, string idPresentation);
        Task<Result> DeleteViewedPresentationAsync(string idStudent, string idPresentation);
        Task<IEnumerable<Presentation>> GetAllViewedPresentationAsync(string id);

        Task<Result> UpdateIsPaidAsync(string id, bool hasPayment);

        Task<IEnumerable<Feedback>> GetAllFeedbacksFromStudentAsync(string id);

    }
}
