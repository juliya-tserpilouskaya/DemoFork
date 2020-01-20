using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;
using System.Threading.Tasks;
using Presentations.Logic.Models;

namespace Presentations.Logic.Interfaces
{
    public interface IPresentationsService : IDisposable
    {
        Task<Result<Presentation>> AddPresentationAsync(PresentationAdd_DTO model);

        Task<Presentation> GetPresentationByIdAsync(string id);

        Task<IEnumerable<Presentation>> GetAllPresentationsAsync();

        Task<Result<Presentation>> UpdatePresentationAsync(Presentation model);

        Task<Result> DeletePresentationByIdAsync(string id);

        Task<bool> ExistPresentationAsync(string title);

        Task<IEnumerable<Student>> GetAllWhoViewedThisPresentationAsync(string id);

        Task<IEnumerable<Student>> GetAllWhoLikeThisPresentationAsync(string id);

        Task<IEnumerable<Feedback>> GetAllFeedbacksPresentationAsync(string id);
    }
}
