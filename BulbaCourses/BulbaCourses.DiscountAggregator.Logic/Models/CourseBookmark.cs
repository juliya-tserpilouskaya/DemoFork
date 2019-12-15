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
        // TODO   //составной первичный курс из IdCourse and UserAccount
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Course IdCourse { get; set; }

        public UserAccount UserAccount { get; set; }
    }
}
