using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface IUserProfileServices
    {
        UserProfile GetByUserId(string userId);
        IEnumerable<UserProfile> GetAll();
        UserProfile Add(UserProfile userProfile);
    }
}