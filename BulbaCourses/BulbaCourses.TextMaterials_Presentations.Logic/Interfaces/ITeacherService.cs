using Presentations.Logic;
using Presentations.Logic.Models;
using Presentations.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Logic.Interfaces
{
    public interface ITeacherService : IDisposable
    {
        /// <summary>
        /// Map UserAdd_DTO to TeacherDB, passes to Add DB-method the TeacherDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Teacher>> AddTeacherAsync(UserAdd_DTO model);

        /// <summary>
        /// Map TeacherDB to Teacher, passes to GetByIdAsync DB-method the id for getting teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Teacher> GetTeacherByIdAsync(string id);

        /// <summary>
        /// Map TeacherDB to Teacher, get all teachers from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        /// <summary>
        /// Map Teacher to TeacherDB, passes to Update DB-method the TeacherDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Teacher>> UpdateTeacherAsync(Teacher model);

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion TeacherDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteTeacherByIdAsync(string id);

        Task<bool> ExistTeacherAsync(string userIdIdentity);

        Task<IEnumerable<Feedback>> GetAllFeedbacksFromTeacherAsync(string id);

        Task<IEnumerable<Presentation>> GetAllChangedPresentationsAsync(string id);
    }
}
