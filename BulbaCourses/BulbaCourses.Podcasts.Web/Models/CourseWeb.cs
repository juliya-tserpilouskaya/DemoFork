using BulbaCourses.Podcasts.Web.Models;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Web.Models
{
    public class CourseWeb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserWeb Author { get; set; }
        public double? Raiting { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<AudioWeb> Audios { get; set; }
        public ICollection<CommentWeb> Comments { get; set; }
    }
}