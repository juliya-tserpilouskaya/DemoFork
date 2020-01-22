using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Data.Models
{
    public class CourseDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserDb Author { get; set; }
        public double Raiting { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<AudioDb> Audios { get; set; }
        public ICollection<CommentDb> Comments { get; set; }
    }
}
