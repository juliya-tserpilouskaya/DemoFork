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
        Task<Result<Teacher>> AddTeacherAsync(UserAdd_DTO model);

        Task<Teacher> GetTeacherByIdAsync(string id);

        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        Task<Result<Teacher>> UpdateTeacherAsync(Teacher model);

        Task<Result> DeleteTeacherByIdAsync(string id);

        Task<bool> ExistTeacherAsync(string userIdIdentity);

        Task<IEnumerable<Feedback>> GetAllFeedbacksFromTeacherAsync(string id);

        Task<IEnumerable<Presentation>> GetAllChangedPresentationsAsync(string id);
    }
}
