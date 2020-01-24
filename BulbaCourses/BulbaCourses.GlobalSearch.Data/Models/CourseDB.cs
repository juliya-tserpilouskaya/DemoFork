using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class CourseDB
    {
        public string Id { get; set; } //= Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int CourseCategoryDBId { get; set; }
        public int AuthorDBId { get; set; }
        public double Cost { get; set; }
        public string Complexity { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public ICollection<CourseItemDB> Items { get; set; }
    }
}
