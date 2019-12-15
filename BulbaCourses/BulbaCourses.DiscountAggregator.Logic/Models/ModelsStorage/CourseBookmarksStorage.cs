using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class CourseBookmarksStorage
    {
        public readonly static List<CourseBookmark> _coursebookmark = new List<CourseBookmark>();

        static CourseBookmarksStorage()
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
