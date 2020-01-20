using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public interface ICourseLoadingRepository
    {
        Task<CourseDB> GetAllPresentationsFromCourseAsync(string id);
    }
}
