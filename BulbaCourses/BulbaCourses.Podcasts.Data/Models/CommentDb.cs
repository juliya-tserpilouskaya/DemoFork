using System;

namespace BulbaCourses.Podcasts.Data.Models
{
    public class CommentDb
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public UserDb User { get; set; }
        public DateTime PostDate { get; set; }
        public CourseDb Course { get; set; }
    }
}
