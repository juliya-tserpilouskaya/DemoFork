using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Data.Models
{
    public class CourseDb
    {
        public string CourseId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public UserDb Author { get; set; }
        public int Level { get; set; }
        public double Raiting { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }

        public ICollection<VideoMaterialDb> Videos { get; set; }
        public ICollection<CommentDb> Comments { get; set; }
        public ICollection<TagDb> Tags { get; set; }
    }
}
