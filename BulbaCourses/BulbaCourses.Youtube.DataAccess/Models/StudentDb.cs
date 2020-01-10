using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class StudentDb : UserDb
    {
        public IEnumerable<CourseDb> PurchasedCourses { get; set; }
    }
}