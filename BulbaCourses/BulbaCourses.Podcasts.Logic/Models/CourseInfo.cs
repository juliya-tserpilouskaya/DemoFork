using BulbaCourses.Podcasts.Logic.Services;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class CourseInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}