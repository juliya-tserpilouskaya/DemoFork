using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class CourseCategoryStorage
    {
        private readonly static List<CourseCategory> _courseCategory = new List<CourseCategory>();

        static CourseCategoryStorage()
        {
            var faker = new Faker<CourseCategory>();
            faker.RuleFor(_ => _.Name, f => f.Company.CompanyName());
            faker.RuleFor(_ => _.Title, f => f.Lorem.Sentence(10));
            _courseCategory = faker.Generate(10);
        }

        public static IEnumerable<CourseCategory> GetAll()
        {
            return _courseCategory.AsReadOnly();
        }

        public static CourseCategory GetById(string id)
        {
            return _courseCategory.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static CourseCategory Add(CourseCategory courseCategory)
        {
            courseCategory.Id = Guid.NewGuid().ToString();
            _courseCategory.Add(courseCategory);
            return courseCategory;
        }
    }
}
