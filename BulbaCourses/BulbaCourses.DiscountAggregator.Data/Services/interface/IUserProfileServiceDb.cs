using System.Collections.Generic;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IUserProfileServiceDb
    {
        void Add(UserProfileDb profile);
        Task<Result<UserProfileDb>> AddAsync(UserProfileDb profileDb);
        void Delete(UserProfileDb profile);
        Task<Result<UserProfileDb>> DeleteAsync(UserProfileDb profileDb);
        IEnumerable<UserProfileDb> GetAll();
        Task<IEnumerable<UserProfileDb>> GetAllAsync();
        UserProfileDb GetById(string id);
        Task<UserProfileDb> GetByIdAsync(string id);
        void Update(UserProfileDb profile);
        Task<Result<UserProfileDb>> UpdateAsync(UserProfileDb profileDb);
        Task<bool> ExistsAsync(string login);
    }
}