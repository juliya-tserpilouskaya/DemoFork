using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Data.Models
{
    public class AuthorDB
    {
        public int Id { get; set; } // = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public ICollection<CourseDB> Courses { get; set; }
    }
}
