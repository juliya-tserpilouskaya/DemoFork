using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Models
{
    public class VideoMaterialInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Duration { get; set; }
        public DateTime Created { get; set; }
        public int NumberOfViews { get; set; }
        public double Raiting { get; set; }
        public int Order { get; set; }
    }
}
