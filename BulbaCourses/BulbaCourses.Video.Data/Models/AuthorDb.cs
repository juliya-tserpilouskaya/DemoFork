using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class AuthorDb
    {
        public string AuthorId { get; set; } = Guid.NewGuid().ToString();
        public UserDb User { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Annotation { get; set; }
        public string Professions { get; set; }
        public ICollection<CourseDb> AuthorCourses { get; set; }
    }
}
