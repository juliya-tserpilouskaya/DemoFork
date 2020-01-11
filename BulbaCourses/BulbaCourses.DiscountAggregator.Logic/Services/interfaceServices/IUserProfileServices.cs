using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IUserProfileServices
    {
        UserProfile GetById(string userId);
        IEnumerable<UserProfile> GetAll();
        Task<IEnumerable<UserProfile>> GetAllAsync();
        UserProfile Add(UserProfile userProfile);
        Task<int> AddAsync(UserProfile profile);
        Task<bool> ExistsAsync(string login);
    }
}