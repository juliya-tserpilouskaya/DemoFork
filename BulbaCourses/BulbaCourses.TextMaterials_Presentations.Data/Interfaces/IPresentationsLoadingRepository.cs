using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data.Interfaces
{
    public interface IPresentationsLoadingRepository
    {
        /// <summary>
        /// Get the presentation by id with all the students who watched it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PresentationDB> GetAllWhoWatchedThisPresentationAsync(string id);

        /// <summary>
        /// Get the presentation by id with all the students who like it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PresentationDB> GetAllWhoLikeThisPresentationAsync(string id);

        /// <summary>
        /// Get the presentation by id with feedbacks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PresentationDB> GetAllFeedbacksPresentationAsync(string id);
    }
}
