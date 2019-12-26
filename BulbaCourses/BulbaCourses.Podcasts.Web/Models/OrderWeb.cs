using BulbaCourses.Video.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Web.Models
{
    public class OrderWeb
    {
        string Id { get; set; }
        CourseWeb BoughtCourse { get; set; }
        UserWeb Customer { get; set; }
        DateTime SaleDate { get;  set; }
        double Price { get; set; }
    }
}
