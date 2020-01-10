using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class CourseDb
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DomainDb Domain { get; set; }

        public string URL { get; set; }

        public CourseCategoryDb Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double OldPrice { get; set; }

        public DateTime? DateOldPrice { get; set; } = DateTime.Now;

        public int Discount { get; set; }

        public DateTime? DateStartCourse { get; set; } = DateTime.Now;

        public DateTime? DateChange { get; set; } = DateTime.Now;
    }
}
