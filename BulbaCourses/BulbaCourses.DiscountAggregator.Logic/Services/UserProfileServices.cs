using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class UserProfileServices : IUserProfileServices
    {
        public UserProfile GetByUserId(string userId)
        {
            return UserProfileStorage.GetByUserId(userId);
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return UserProfileStorage.GetAll();
        }

        public UserProfile Add(UserProfile userProfile)
        {
            return UserProfileStorage.Add(userProfile);
        }
    }
}
