using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Models
{
    public class Tag
    {
        public string TagId { get; set; } = Guid.NewGuid().ToString();
        public string Content { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
