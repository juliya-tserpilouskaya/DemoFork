using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IUserProfileServices
    {
        UserProfile GetById(string userId);
        Task<UserProfile> GetByIdAsync(string id);
        IEnumerable<UserProfile> GetAll();
        Task<IEnumerable<UserProfile>> GetAllAsync();
        UserProfile Add(UserProfile userProfile);
        Task<Result<UserProfile>> AddAsync(UserProfile profile);
        Task<Result<UserProfile>> UpdateAsync(UserProfile profile);
        Task<Result<UserProfile>> DeleteByIdAsync(string idProfile);
        Task<bool> ExistsAsync(string email);
    }
}