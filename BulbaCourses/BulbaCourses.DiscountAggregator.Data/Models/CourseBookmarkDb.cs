using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Models
{
    public class CourseBookmarkDb
    {
        public string Id { get; set; }

        public UserProfileDb UserProfile { get; set; }

        public ICollection<CourseDb> Course { get; set; }        
    }
}
