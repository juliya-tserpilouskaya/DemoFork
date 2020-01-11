using System.Collections.Generic;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IUserProfileServiceDb
    {
        void Add(UserProfileDb profile);
        Task<int> AddAsync(UserProfileDb profileDb);
        void Delete(UserProfileDb profile);
        Task<UserProfileDb> DeleteAsync(UserProfileDb profileDb);
        IEnumerable<UserProfileDb> GetAll();
        UserProfileDb GetById(string id);
        Task<UserProfileDb> GetByIdAsync(string id);
        void Update(UserProfileDb profile);
        Task<UserProfileDb> UpdateAsync(UserProfileDb profileDb);
        Task<bool> ExistsAsync(string login);
        Task<IEnumerable<UserProfileDb>> GetAllAsync();
    }
}