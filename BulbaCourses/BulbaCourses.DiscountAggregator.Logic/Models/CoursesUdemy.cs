using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class CoursesUdemy
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }
    }
}
