using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class VideoMaterialDb
    {
        public string VideoId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Url { get; set; }
        public int Duration { get; set; }
        public DateTime Created { get; set; }
        public int NumberOfViews { get; set; }
        public double Raiting { get; set; }
        public int Order { get; set; }

        public string CourseId { get; set; }
        public ICollection<CommentDb> Comments { get; set; }
    }
}
