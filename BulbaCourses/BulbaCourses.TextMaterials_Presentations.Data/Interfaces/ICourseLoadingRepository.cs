using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.TextMaterials_Presentations.Data
{
    public interface ICourseLoadingRepository
    {
        /// <summary>
        /// Get the course by id whith presentations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CourseDB> GetAllPresentationsFromCourseAsync(string id);
    }
}
