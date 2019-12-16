using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class DomainStorage
    {
        private readonly static List<Domain> _domains = new List<Domain>();

        static DomainStorage()
        {
            var faker = new Faker<Domain>();
            faker.RuleFor(_ => _.DomainURL, f => f.Internet.Url());
            faker.RuleFor(_ => _.DomainName, f => f.Lorem.Sentence(10));
            _domains = faker.Generate(10);
    }

        public static IEnumerable<Domain> GetAll()
        {
            return _domains.AsReadOnly();
        }

        public static Domain GetById(string id)
        {
            return _domains.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static Domain Add(Domain domain)
        {
            domain.Id = Guid.NewGuid().ToString();
            _domains.Add(domain); 
            return domain;
        }
    }
}
