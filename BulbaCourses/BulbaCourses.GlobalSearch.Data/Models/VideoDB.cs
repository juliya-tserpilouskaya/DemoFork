using BulbaCourses.GlobalSearch.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class VideoDB : ILearningCourseItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Duration { get; set; }
    }
}
