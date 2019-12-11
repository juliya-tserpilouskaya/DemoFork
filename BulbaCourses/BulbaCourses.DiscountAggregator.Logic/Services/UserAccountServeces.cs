using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Logic.Models;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class UserAccountServeces : IUserAccountServise
    {
        public void Add(UserAccount user)
        {
            UserAccountCollection.Add(user);
        }

        public void Delete(UserAccount user)
        {
            UserAccountCollection.DeleteById(user.Id);
        }

        public void DeleteById(string userId)
        {
            //var user = UserAccountCollection.GetById(userId);
            UserAccountCollection.DeleteById(userId);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return UserAccountCollection.GetAll();
        }

        public UserAccount GetByLogin(string login)
        {
            var user = UserAccountCollection.GetAll().FirstOrDefault(c => c.Login.Equals(login));
            return user;
        }

        public UserAccount GetUserById(string id)
        {
            var result = UserAccountCollection.GetById(id);
            return result;
        }
    }

}
