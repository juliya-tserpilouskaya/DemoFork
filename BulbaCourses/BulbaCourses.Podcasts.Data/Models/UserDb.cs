using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Data.Models
{
    public class UserDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<OrderDb> UploadedCourses { get; set; }
        public ICollection<OrderDb> BoughtCourses { get; set; }
        public ICollection<CourseDb> Comments { get; set; }
    }
}