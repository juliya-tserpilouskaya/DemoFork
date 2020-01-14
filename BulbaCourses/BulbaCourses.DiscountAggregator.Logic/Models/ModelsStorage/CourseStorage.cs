using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class CourseStorage
    {
        private readonly static List<Course> _course = new List<Course>();

        static CourseStorage()
        {
            var faker = new Faker<Course>();
            faker.RuleFor(_ => _.URL, f => f.Internet.Url());
            //faker.RuleFor(_ => _.Category, f => f.Company.CompanyName());
            faker.RuleFor(_ => _.Title, f => f.Lorem.Sentence(10));
            faker.RuleFor(_ => _.Price, f => f.Random.Double(0, 100000));
            faker.RuleFor(_ => _.Discount, f => f.Random.Int(1, 99));
            faker.RuleFor(_ => _.Description, f => f.Lorem.Sentences(13));
            _course = faker.Generate(10);
        }

        public static IEnumerable<Course> GetAll()
        {
            return _course.AsReadOnly();
        }

        public static Course GetById(string id)
        {
            return _course.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static Course Add(Course course)
        {
            course.Id = Guid.NewGuid().ToString();
            _course.Add(course);    // id записи вы формируем на стороне сервера, а не на стороне клиента
            return course;
        }
    }
}
