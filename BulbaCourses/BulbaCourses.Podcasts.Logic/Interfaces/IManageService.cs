using BulbaCourses.Podcasts.Logic.Services;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public interface IManageService
    {
        Course Add(Course course);
        void Delete(string id);
        Course Edit(Course course);
        Course GetById(string id);
    }
}