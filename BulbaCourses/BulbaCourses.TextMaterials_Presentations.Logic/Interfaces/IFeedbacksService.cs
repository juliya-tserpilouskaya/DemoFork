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
        /// <summary>
        /// Map FeedbackAdd_DTO to FeedbackDB, passes to Add DB-method the FeedbackDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Feedback>> AddFeedbackAsync(FeedbackAdd_DTO model);

        /// <summary>
        /// Map FeedbackDB to Feedback, passes to GetByIdAsync DB-method the id for getting feedback
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Feedback> GetFeedbackByIdAsync(string id);

        /// <summary>
        /// Map FeedbackDB to Feedback, get all courses from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();

        /// <summary>
        /// Map Feedback to FeedbackDB, passes to Update DB-method the FeedbackDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Feedback>> UpdateFeedbackAsync(Feedback model);

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion FeedbackDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeleteFeedbackByIdAsync(string id);
    }
}
