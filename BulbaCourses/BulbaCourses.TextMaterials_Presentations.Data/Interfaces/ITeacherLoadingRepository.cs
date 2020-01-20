using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data.Interfaces
{
    public interface ITeacherLoadingRepository
    {
        Task<TeacherDB> GetAllFeedbacksFromTeacherAsync(string id);
        Task<TeacherDB> GetAllChangedPresentationsAsync(string id);
    }
}
