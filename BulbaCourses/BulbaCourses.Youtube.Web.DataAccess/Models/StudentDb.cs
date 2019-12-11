using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.Web.DataAccess.Models
{
    public class StudentDb : UserDb
    {
        public IEnumerable<CourseDb> PurchasedCourses { get; set; }
    }
}