using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Models
{
    public class CourseInfo
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public UserInfo Author { get; set; }
        public int Level { get; set; }
        public double Raiting { get; set; }
        public int RateCount { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
    }
}
