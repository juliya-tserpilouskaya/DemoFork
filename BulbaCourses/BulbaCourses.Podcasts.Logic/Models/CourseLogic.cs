using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class CourseLogic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserLogic Author { get; set; }
        public double? Raiting { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<AudioLogic> Audios { get; set; }
        public ICollection<CommentLogic> Comments { get; set; }
    }
}
