using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Data.Models
{
    public class OrderDb
    {
        string Id { get; set; }
        CourseDb BoughtCourse { get; set; }
        UserDb Customer { get; set; }
        DateTime SaleDate { get;  set; }
        double Price { get; set; }
    }
}
