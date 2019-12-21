using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    class SearchService : ISearchService
    {
        public IEnumerable<LearningCourseDTO> Search()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LearningCourseDTO>> SearchAsync()
        {
            throw new NotImplementedException();
        }
    }
}
