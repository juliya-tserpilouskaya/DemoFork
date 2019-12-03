using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Models
{
    public class VideoMaterial
    {
        public string VideoId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime Created { get; set; }
        public int NumberOfViews { get; set; }
        public double Raiting { get; set; }
        public int Order { get; set; }

        public string CourseId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
