using BulbaCourses.DiscountAggregator.Logic.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class CourseITAcademyStorage
    {
        private readonly static List<CoursesITAcademy> _course = new List<CoursesITAcademy>();

        static CourseITAcademyStorage()
        {
            ParserITAcademy parserITAcademy = new ParserITAcademy();
            _course.AddRange((List<CoursesITAcademy>)parserITAcademy
                .GetAllCourses(new CourseCategory()
                    { Name = CommonValues.programmirovanieCategoryItAcademy,
                      Title = "Programs" 
                    }));
        }
        public static IEnumerable<CoursesITAcademy> GetAll()
        {
            return _course.AsReadOnly();
        }

        public static CoursesITAcademy GetById(string id)
        {
            return _course.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static CoursesITAcademy Add(CoursesITAcademy course)
        {
            course.Id = Guid.NewGuid().ToString();
            _course.Add(course);    // id записи вы формируем на стороне сервера, а не на стороне клиента
            return course;
        }
    }
}
