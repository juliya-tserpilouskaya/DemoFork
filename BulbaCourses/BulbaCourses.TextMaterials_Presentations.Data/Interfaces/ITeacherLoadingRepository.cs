using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data.Interfaces
{
    public interface ITeacherLoadingRepository
    {
        /// <summary>
        /// Get the teacher whith all feedbacks of this teacher by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TeacherDB> GetAllFeedbacksFromTeacherAsync(string id);

        /// <summary>
        /// Get the teacher whith all presentations of this teacher by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TeacherDB> GetAllChangedPresentationsAsync(string id);
    }
}
