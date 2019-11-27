using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Models
{
    public class Student : User
    {
        public List<Course> PurchasedCourses { get; set; }
    }
}