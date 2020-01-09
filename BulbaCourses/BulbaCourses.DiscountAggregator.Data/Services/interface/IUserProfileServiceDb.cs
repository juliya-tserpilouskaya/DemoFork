using System.Collections.Generic;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IUserProfileServiceDb
    {
        void Add(UserProfileDb profile);
        void Delete(UserProfileDb profile);
        IEnumerable<UserProfileDb> GetAll();
        UserProfileDb GetById(string id);
        void Update(UserProfileDb profile);
    }
}