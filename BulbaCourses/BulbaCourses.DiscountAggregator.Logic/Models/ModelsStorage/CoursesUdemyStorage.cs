using BulbaCourses.DiscountAggregator.Logic.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    class CoursesUdemyStorage
    {
        private readonly static List<CoursesUdemy> _course = new List<CoursesUdemy>();

        static CoursesUdemyStorage()
        {
            ParserUdemy parserITAcademy = new ParserUdemy();
            _course.AddRange((List<CoursesUdemy>)parserITAcademy.GetAllCourses());
        }
        public static IEnumerable<CoursesUdemy> GetAll()
        {
            return _course.AsReadOnly();
        }

        public static CoursesUdemy GetById(string id)
        {
            return _course.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static CoursesUdemy Add(CoursesUdemy course)
        {
            course.Id = Guid.NewGuid().ToString();
            _course.Add(course);    // id записи вы формируем на стороне сервера, а не на стороне клиента
            return course;
        }
    }
}
