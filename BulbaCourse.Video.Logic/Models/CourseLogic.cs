using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourse.Video.Logic.Models
{
    public class CourseLogic
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public UserLogic Author { get; set; }
        public int Level { get; set; }
        public double Raiting { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
    }
}
