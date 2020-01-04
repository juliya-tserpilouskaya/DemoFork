using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IUserAccountService
    {
        IEnumerable<UserAccount> GetAll();
        Task<IEnumerable<UserAccount>> GetAllAsync();
        UserAccount GetByLogin(string login);
        UserAccount GetUserById(string id);
        void Add(UserAccount user);
        void Delete(UserAccount user);
        void DeleteById(string userId);
        void Update(UserAccount user);
        Task<bool> ExistsAsync(string login);
        //Task<UserAccount> GetUserByIdAsync(string id);
    }
}
