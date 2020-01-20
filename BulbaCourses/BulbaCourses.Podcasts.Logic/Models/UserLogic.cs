using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class UserLogic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<CourseLogic> UploadedCourses { get; set; }
        public ICollection<CourseLogic> BoughtCourses { get; set; }
        public ICollection<CommentLogic> Comments { get; set; }
    }
}