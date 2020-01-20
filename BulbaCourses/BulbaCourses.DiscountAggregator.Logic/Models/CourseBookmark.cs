using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class CourseBookmark
    {
        public string Id { get; set; }

        public IEnumerable<Course> Course { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
