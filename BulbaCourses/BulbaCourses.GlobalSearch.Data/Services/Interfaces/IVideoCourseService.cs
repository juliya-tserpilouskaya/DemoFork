using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface IVideoCourseService
    {
        IEnumerable<VideoCourseDB> GetAllCourses();
        VideoCourseDB GetById(string id);
        IEnumerable<VideoCourseDB> GetByCategory(string category);
        IEnumerable<VideoCourseDB> GetByAuthorId(int id);
        IEnumerable<VideoDB> GetLearningItemsByCourseId(string id);
        IEnumerable<VideoCourseDB> GetCourseByComplexity(string complexity);
        IEnumerable<VideoCourseDB> GetCourseByLanguage(string lang);
        IEnumerable<VideoCourseDB> GetCourseByQuery(string query);
    }
}
