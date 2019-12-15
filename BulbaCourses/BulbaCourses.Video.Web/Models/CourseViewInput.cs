using BulbaCourses.Video.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models
{
    public class CourseViewInput
    {
        public string Name { get; set; }
        public CourseLevel Level { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}