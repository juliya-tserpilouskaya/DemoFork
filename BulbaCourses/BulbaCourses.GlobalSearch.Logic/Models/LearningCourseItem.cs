using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Logic.Models
{
    public abstract class LearningCourseItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}