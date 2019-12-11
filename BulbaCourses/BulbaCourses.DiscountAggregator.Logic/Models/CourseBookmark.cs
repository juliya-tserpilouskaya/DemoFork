using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models
{
    public class CourseBookmark
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Course IdCourse { get; set; }
    }
    public static class FakerCourseBookmarks
    {
        public readonly static List<CourseBookmark> _coursebookmark = new List<CourseBookmark>();

        static FakerCourseBookmarks()
        {
            var faker = new Faker<CourseBookmark>();
            _coursebookmark = faker.Generate(5);
        }

        public static IEnumerable<CourseBookmark> GetAll()
        {
            return _coursebookmark.AsReadOnly();
        }


        public static CourseBookmark Add(CourseBookmark coursebookmark)
        {
            coursebookmark.Id = Guid.NewGuid().ToString();
            _coursebookmark.Add(coursebookmark);
            return coursebookmark;
        }

        public static IEnumerable<CourseBookmark> Delete(string id)
        {
            var itemToDelete = _coursebookmark.Where(x => x.Id == id).First();
            _coursebookmark.Remove(itemToDelete);
            return _coursebookmark.AsReadOnly();
        }

    }

}
