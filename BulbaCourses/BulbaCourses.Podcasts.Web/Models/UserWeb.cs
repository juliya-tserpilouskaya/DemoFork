using BulbaCourses.Podcasts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Podcasts.Web.Models
{
    public class UserWeb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<CourseWeb> UploadedCourses { get; set; }
        public ICollection<CourseWeb> BoughtCourses { get; set; }
        public ICollection<CommentWeb> Comments { get; set; }
    }
}