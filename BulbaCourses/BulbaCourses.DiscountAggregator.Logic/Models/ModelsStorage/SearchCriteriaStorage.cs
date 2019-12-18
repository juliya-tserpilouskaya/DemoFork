using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class SearchCriteriaStorage
    {
        private readonly static List<SearchCriteria> _criterias = new List<SearchCriteria>();

        static SearchCriteriaStorage()
        {
            var faker = new Faker<SearchCriteria>();
            faker.RuleFor(_ => _.MaxPrice, f => f.Random.Double(1, 100000)); 
            faker.RuleFor(_ => _.MinPrice, f => f.Random.Double(1, 100000));
            faker.RuleFor(_ => _.MaxDiscount, f => f.Random.Int(0, 70));
            faker.RuleFor(_ => _.MinDiscount, f => f.Random.Int(0, 70));

            _criterias = faker.Generate(10);
        }

        public static IEnumerable<SearchCriteria> GetAll()
        {
            return _criterias.AsReadOnly();
        }

        public static SearchCriteria GetByUserId(string userId)
        {
            return _criterias.SingleOrDefault(b => b.UserId.Equals(userId,
                StringComparison.OrdinalIgnoreCase));
        }

        public static SearchCriteria Add(SearchCriteria criteria)
        {
            criteria.UserId = Guid.NewGuid().ToString();
            _criterias.Add(criteria);
            return criteria;
        }
    }
}
