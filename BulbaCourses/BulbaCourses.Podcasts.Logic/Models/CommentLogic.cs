using System;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class CommentLogic
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public UserLogic User { get; set; }
        public DateTime PostDate { get; set; }
        public CourseLogic Course { get; set; }
    }
}
