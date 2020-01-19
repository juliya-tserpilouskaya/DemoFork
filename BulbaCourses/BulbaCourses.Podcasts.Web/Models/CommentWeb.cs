using BulbaCourses.Podcasts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Web.Models
{
    public class CommentWeb
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public UserWeb User { get; set; }
        public DateTime PostDate { get; set; }
        public CourseWeb Course { get; set; }
    }
}