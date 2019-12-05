using BulbaCourses.GlobalSearch.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models.Courses
{
    public class ExcerciseCourseDB
    {
        public string Id { get; set; }
        public ICollection<PodcastDB> Items { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public Complexity Complexity { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
