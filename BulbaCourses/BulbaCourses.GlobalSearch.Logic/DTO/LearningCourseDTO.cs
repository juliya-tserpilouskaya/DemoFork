using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.DTO
{
    public class LearningCourseDTO
    {
        public string Id { get; set; }
        public List<LearningCourseItemDTO> Items { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public double Cost { get; set; }
        public string Complexity { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
    }
}
