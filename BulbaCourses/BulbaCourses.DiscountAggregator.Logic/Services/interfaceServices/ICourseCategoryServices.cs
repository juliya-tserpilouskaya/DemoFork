using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ICourseCategoryServices
    {
        CourseCategory GetById(string id);
        IEnumerable<CourseCategory> GetAll();
        CourseCategory Add(CourseCategory course);
    }
}
