using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Services.Interfaces
{
    public interface ITestCourseService
    {
        IEnumerable<TestCourseDB> GetAllCourses();
        TestCourseDB GetById(string id);
        IEnumerable<TestCourseDB> GetByCategory(string category);
        IEnumerable<TestCourseDB> GetByAuthorId(int id);
        IEnumerable<TestDB> GetLearningItemsByCourseId(string id);
        IEnumerable<TestCourseDB> GetCourseByComplexity(string complexity);
        IEnumerable<TestCourseDB> GetCourseByLanguage(string lang);
        IEnumerable<TestCourseDB> GetCourseByQuery(string query);
    }
}
