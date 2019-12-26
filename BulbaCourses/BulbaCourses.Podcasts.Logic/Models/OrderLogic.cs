using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class OrderLogic
    {
        string Id { get; set; }
        CourseLogic BoughtCourse { get; set; }
        UserLogic Customer { get; set; }
        DateTime SaleDate { get;  set; }
        double Price { get; set; }
    }
}
