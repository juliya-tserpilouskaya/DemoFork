using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Logic.Models
{
    public class LearningCourse
    {
        public string Id { get; set; }
        public List<LearningCourseItem> Items { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public double Cost { get; set; }
        public string Complexity { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
    }
}