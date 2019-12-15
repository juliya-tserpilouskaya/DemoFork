using System.Collections.Generic;
using BulbaCourses.DiscountAggregator.Logic.Models;

namespace BulbaCourses.DiscountAggregator.Logic.Parsers
{
    interface ICoursesParser
    {
        IEnumerable<CoursesITAcademy> GetAllCourses();
    }
}