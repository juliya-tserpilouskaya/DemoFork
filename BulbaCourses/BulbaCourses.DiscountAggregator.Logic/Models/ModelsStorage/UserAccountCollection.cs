using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage
{
    public static class UserAccountCollection
    {
        private readonly static List<UserAccount> _accounts = new List<UserAccount>();

        static UserAccountCollection()
        {
            var faker = new Faker<UserAccount>();
            faker.RuleFor(_ => _.Login, f => f.Name.JobTitle());
            faker.RuleFor(_ => _.Email, f => f.Internet.Email());
            faker.RuleFor(_ => _.Password, f => f.Internet.Password());
            _accounts = faker.Generate(10);
        }

        public static IEnumerable<UserAccount> GetAll()
        {
            return _accounts.AsReadOnly();
        }

        public static UserAccount GetById(string id)
        {
            return _accounts.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static UserAccount Add(UserAccount userAccount)
        {
            userAccount.Id = Guid.NewGuid().ToString();
            _accounts.Add(userAccount);    // id записи вы формируем на стороне сервера, а не на стороне клиента
            return userAccount;
        }

        public static IEnumerable<UserAccount> Delete(UserAccount userAccount)
        {
            _accounts.Remove(userAccount);
            return _accounts.AsReadOnly();
        }

        //internal static Task<UserAccount> GetByIdAsync(string id)
        //{
        //    return _accounts.SingleOrDefault(b => b.Id.Equals(id,
        //        StringComparison.OrdinalIgnoreCase));
        //}

        public static IEnumerable<UserAccount> DeleteById(string id)
        {
            var itemToDelete = _accounts.Where(x => x.Id == id).First();
            _accounts.Remove(itemToDelete);
            return _accounts.AsReadOnly();
        }
    }
}
