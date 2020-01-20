using System;
using System.Collections.Generic;
using System.Text;
using Presentations.Logic.Repositories;
using System.Threading.Tasks;
using Presentations.Logic.Models;

namespace Presentations.Logic.Interfaces
{
    public interface IFeedbacksService : IDisposable
    {
        Task<Result<Feedback>> AddFeedbackAsync(FeedbackAdd_DTO model);

        Task<Feedback> GetFeedbackByIdAsync(string id);

        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();

        Task<Result<Feedback>> UpdateFeedbackAsync(Feedback model);

        Task<Result> DeleteFeedbackByIdAsync(string id);
    }
}
