using BulbaCourses.Podcasts.Logic.Services;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Logic.Models
{
    internal class Account
    {
        internal string Id { get; set; } = Guid.NewGuid().ToString();
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        private List<Course> BoughtCourses = new List<Course>();
        private List<Course> OwnedCourses = new List<Course>();
    }
}