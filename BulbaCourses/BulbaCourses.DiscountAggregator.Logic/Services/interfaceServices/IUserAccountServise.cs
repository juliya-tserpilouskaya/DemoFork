using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IUserAccountServise
    {
        IEnumerable<UserAccount> GetAll();
        UserAccount GetByLogin(string login);
        UserAccount GetUserById(string id);
        void Add(UserAccount user);
        void Delete(UserAccount user);
        void DeleteById(string userId);
    }
}
