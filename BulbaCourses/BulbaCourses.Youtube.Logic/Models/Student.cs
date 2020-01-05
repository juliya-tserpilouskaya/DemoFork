using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Logic.Models
{
    public class Student : User
    {
        public IEnumerable<Course> PurchasedCourses { get; set; }
    }
}