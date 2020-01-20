using System;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public class Course
    {
        internal string Id { get; set; } = Guid.NewGuid().ToString();
        internal string FileLink { get; set; }
        internal string Description { get; set; }
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal double Price { get; set; }
        internal string Theme { get; set; }
        internal DateTime? Created { get; set; }
        internal DateTime? Modified { get; set; }
    }
}