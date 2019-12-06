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
        public string Title { get; set; }
        public string URL { get; set; }
    }
    public static class FakerCourseBookmarks
    {
        public readonly static List<CourseBookmark> _coursebookmark = new List<CourseBookmark>();

        static FakerCourseBookmarks()
        {
            var faker = new Faker<CourseBookmark>();
            faker.RuleFor(_ => _.URL, f => f.Internet.Url());
            faker.RuleFor(_ => _.Title, f => f.Lorem.Sentence(10));
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

        //public static CourseBookmark Delete(CourseBookmark coursebookmark)
        //{
        //    _coursebookmark.(coursebookmark);
        //    return coursebookmark;
        //}

    }

}
