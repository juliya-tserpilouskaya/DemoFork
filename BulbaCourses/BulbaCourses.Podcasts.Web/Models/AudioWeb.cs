using BulbaCourses.Podcasts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Web.Models
{
    public class AudioWeb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Content { get; set; }
        public CourseWeb Course { get; set; }
    }
    
}