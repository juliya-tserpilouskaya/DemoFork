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
        IEnumerable<UserProfileDb> GetAll();
        UserProfileDb GetById(string id);
        void Update(UserProfileDb profile);
        Task<bool> ExistsAsync(string login);
        Task<IEnumerable<UserProfileDb>> GetAllAsync();
    }
}