using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseUdemyServices : ICourseUdemyServices
    {
        public IEnumerable<CoursesUdemy> GetAll()
        {
            return CoursesUdemyStorage.GetAll();
        }
    }
}
