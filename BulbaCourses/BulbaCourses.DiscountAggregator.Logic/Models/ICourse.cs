using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public interface ICourse
    {
        string Id { get; set; }

        Domain Domain { get; set; }

        string URL { get; set; }
        CourseCategory Category { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        double Price { get; set; }

        double OldPrice { get; set; }

        DateTime? DateOldPrice { get; set; }

        int Discount { get; set; }

        DateTime? DateStartCourse { get; set; }

        DateTime? DateChange { get; set; }
    }
}
