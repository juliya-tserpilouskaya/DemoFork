using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data.Interfaces
{
    public interface IPresentationsLoadingRepository
    {
        Task<PresentationDB> GetAllWhoViewedThisPresentationAsync(string id);

        Task<PresentationDB> GetAllWhoLikeThisPresentationAsync(string id);

        Task<PresentationDB> GetAllFeedbacksPresentationAsync(string id);
    }
}
