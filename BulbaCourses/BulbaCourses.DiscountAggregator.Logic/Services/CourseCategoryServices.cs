using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class CourseCategoryServices : ICourseCategoryServices
    {
        public CourseCategory Add(CourseCategory courseCategory)
        {
            return CourseCategoryStorage.Add(courseCategory);
        }

        public IEnumerable<CourseCategory> GetAll()
        {
            return CourseCategoryStorage.GetAll();
        }

        public CourseCategory GetById(string id)
        {
            return CourseCategoryStorage.GetById(id);
        }
    }
}
