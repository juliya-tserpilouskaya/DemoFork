using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class TagDb
    {
        public string TagId { get; set; }// = Guid.NewGuid().ToString();
        public string Content { get; set; }

        public ICollection<CourseDb> Courses { get; set; }
    }
}
