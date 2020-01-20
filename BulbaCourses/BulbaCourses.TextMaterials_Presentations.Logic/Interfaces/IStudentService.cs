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
        Task<Result<Student>> AddStudentAsync(UserAdd_DTO model);

        Task<Student> GetStudentByIdAsync(string id);

        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<Result<Student>> UpdateStudentAsync(Student model);

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
