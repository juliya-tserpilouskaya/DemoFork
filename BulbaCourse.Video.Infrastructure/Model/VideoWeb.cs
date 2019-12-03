using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Infrastructure.Model
{
    public class VideoWeb
    {
        public string VideoId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime Created { get; set; }
        public int NumberOfViews { get; set; }
        public double Raiting { get; set; }
        public int SerialNumber { get; set; }
        public string OwnerId { get; set; }

      

      //  public ICollection<Comment> Comments { get; set; }
    }
}
