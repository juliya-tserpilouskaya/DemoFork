using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using BulbaCourses.DiscountAggregator.Logic.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public class CourseITAcademyServices : ICourseITAcademyServices
    {
        public IEnumerable<CoursesITAcademy> GetAll()
        {
            return CourseStore.GetAll();
        }
    }
}
