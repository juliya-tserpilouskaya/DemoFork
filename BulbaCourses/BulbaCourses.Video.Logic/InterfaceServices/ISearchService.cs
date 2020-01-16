using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface ISearchService
    {
        Task<IEnumerable<CourseInfo>> GetSearchCourses(string searchRequest, SearchVariant variant);
    }
}
