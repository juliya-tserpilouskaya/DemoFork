using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class CourseItemDB
    {
        public string Id { get; set; } // = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CourseDBId { get; set; }
    }
}
