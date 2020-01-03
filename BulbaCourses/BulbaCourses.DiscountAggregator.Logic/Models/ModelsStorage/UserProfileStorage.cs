using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class UserProfileStorage
    {
        private readonly static List<UserProfile> _profiles = new List<UserProfile>();

        static UserProfileStorage()
        {
            var faker = new Faker<UserProfile>();
            //faker.RuleFor(_ => _.Id, f => f.Person.UserName);
            faker.RuleFor(_ => _.FirstName, f => f.Person.FirstName);
            faker.RuleFor(_ => _.LastName, f => f.Person.LastName);
            faker.RuleFor(_ => _.DateOfBirth, f => f.Person.DateOfBirth);
            //faker.RuleFor(_ => _.SearchCriterias, f => f.Lorem.Sentence(10));
            faker.RuleFor(_ => _.Subscription, f => f.Random.Bool());
            faker.RuleFor(_ => _.SubscriptionDateStart, f => f.Date.Between(DateTime.Now,DateTime.Now));
            faker.RuleFor(_ => _.SubscriptionDateEnd, f => f.Date.Between(DateTime.Now, DateTime.UtcNow));
            
            _profiles = faker.Generate(10);
    }

        public static IEnumerable<UserProfile> GetAll()
        {
            return _profiles.AsReadOnly();
        }

        public static UserProfile GetById(string id)
        {
            return _profiles.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static UserProfile Add(UserProfile userProfile)
        {
            //userProfile.Id = Guid.NewGuid().ToString();
            _profiles.Add(userProfile);
            return userProfile;
        }
    }
}
