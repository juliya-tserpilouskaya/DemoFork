using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class AudioLogic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Content { get; set; }
        public CourseLogic Course { get; set; }
    }
}