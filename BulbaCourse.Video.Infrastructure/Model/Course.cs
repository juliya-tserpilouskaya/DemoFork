using BulbaCourse.Video.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Infrastructure.Model
{
    public class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        public CourseLevel Level { get; set; } 
        public double Raiting { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }

        //public IList<VideoItem> Videos { get; set; }
        //public ICollection<Comment> Comments { get; set; }
        //public ICollection<Tag> Tags { get; set; }
    }
}
