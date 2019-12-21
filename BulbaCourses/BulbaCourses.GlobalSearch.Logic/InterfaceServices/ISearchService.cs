using BulbaCourses.GlobalSearch.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ISearchService
    {
        IEnumerable<LearningCourseDTO> Search(string query);
        IEnumerable<LearningCourseDTO> GetIndexedCourses();
        Task<IEnumerable<LearningCourseDTO>> SearchAsync();
    }
}
