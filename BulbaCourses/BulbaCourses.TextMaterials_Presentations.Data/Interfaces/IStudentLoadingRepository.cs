using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data.Interfaces
{
    public interface IStudentLoadingRepository
    {
        /// <summary>
        /// Add favorite presentation to the collection of favorite
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        void AddLovedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Delete favorite presentation from the collection of favorite
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        void DeleteLovedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Gel the student whith all favorite presentation from the collection of favorite by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDB> GetAllLovedPresentationAsync(string id);

        /// <summary>
        /// Add watched presentation to the collection of watched
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        void AddWatchedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Delete watched presentation from the collection of watched
        /// </summary>
        /// <param name="idStudent"></param>
        /// <param name="idPresentation"></param>
        void DeleteWatchedPresentationAsync(string idStudent, string idPresentation);

        /// <summary>
        /// Get the student whith all watched presentation from the collection of watched by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDB> GetAllWatchedPresentationAsync(string id);

        /// <summary>
        /// Update the payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hasPayment"></param>
        /// <returns></returns>
        Task UpdateIsPaidAsync(string id, bool hasPayment);

        /// <summary>
        /// Get the student whith all feedbacks of this student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDB> GetAllFeedbacksFromStudentAsync(string id);
    }
}
