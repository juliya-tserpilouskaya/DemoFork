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
        /// <summary>
        /// Map PresentationAdd_DTO to PresentationDB, passes to Add DB-method the PresentationDB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Presentation>> AddPresentationAsync(PresentationAdd_DTO model);

        /// <summary>
        /// Map PresentationDB to Presentation, passes to GetByIdAsync DB-method the id for getting presentation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Presentation> GetPresentationByIdAsync(string id);

        /// <summary>
        /// Map PresentationDB to Presentation, get all courses from the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Presentation>> GetAllPresentationsAsync();

        /// <summary>
        /// Map Presentation to PresentationDB, passes to Update DB-method the PresentationDB for updating
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result<Presentation>> UpdatePresentationAsync(Presentation model);

        /// <summary>
        /// Passes to DeleteById DB-method the id for deletion PresentationDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Result> DeletePresentationByIdAsync(string id);

        Task<bool> ExistPresentationAsync(string title);

        /// <summary>
        /// Get the students who watched the presentation by presentation id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllWhoWatchedThisPresentationAsync(string id);

        /// <summary>
        /// Get the students who like the presentation by presentation id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllWhoLikeThisPresentationAsync(string id);

        /// <summary>
        /// Get the feedbacks of the presentation by presentation id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Feedback>> GetAllFeedbacksPresentationAsync(string id);
    }
}
