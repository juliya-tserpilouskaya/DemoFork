using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Models
{
    public class CourseDb
    {

        public string CourseId { get; set; } = Guid.NewGuid().ToString(); //Guid generate in view layer!! No, Guid generate in data layer :) 
        public string Name { get; set; }
        public AuthorDb Author { get; set; }
        public int Level { get; set; }
        public double Raiting { get; set; }
        public int RateCount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }

        public ICollection<VideoMaterialDb> Videos { get; set; }
        public ICollection<TagDb> Tags { get; set; }
    }
}
