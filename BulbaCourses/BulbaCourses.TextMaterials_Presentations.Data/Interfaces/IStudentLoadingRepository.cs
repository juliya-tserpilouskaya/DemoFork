using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data.Interfaces
{
    public interface IStudentLoadingRepository
    {
        Task AddLovedPresentationAsync(string idStudent, string idPresentation);
        Task DeleteLovedPresentationAsync(string idStudent, string idPresentation);
        Task<StudentDB> GetAllLovedPresentationAsync(string id);

        Task AddViewedPresentationAsync(string idStudent, string idPresentation);
        Task DeleteViewedPresentationAsync(string idStudent, string idPresentation);
        Task<StudentDB> GetAllViewedPresentationAsync(string id);

        Task UpdateIsPaidAsync(string id, bool hasPayment);

        Task<StudentDB> GetAllFeedbacksFromStudentAsync(string id);
    }
}
