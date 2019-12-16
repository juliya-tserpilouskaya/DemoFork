using BulbaCourses.Video.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.Models.CourseViews
{
    public class CourseView
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public CourseLevel Level { get; set; }
        public double Raiting { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
    }
}