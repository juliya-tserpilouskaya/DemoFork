using BulbaCourses.Podcasts.Logic.Services;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public interface IManageService
    {
        Course Add(Course course);
        void Delete(Course course);
        Course Edit(Course course);
        Course GetById(string id);
        CourseInfo GetCourseInfo(string id);
    }
}