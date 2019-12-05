using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface IPodcastCourseService
    {
        IEnumerable<PodcastCourseDB> GetAllCourses();
        PodcastCourseDB GetById(string id);
        IEnumerable<PodcastCourseDB> GetByCategory(string category);
        IEnumerable<PodcastCourseDB> GetByAuthorId(int id);
        IEnumerable<PodcastDB> GetLearningItemsByCourseId(string id);
        IEnumerable<PodcastCourseDB> GetCourseByComplexity(string complexity);
        IEnumerable<PodcastCourseDB> GetCourseByLanguage(string lang);
        IEnumerable<PodcastCourseDB> GetCourseByQuery(string query);
    }
}
