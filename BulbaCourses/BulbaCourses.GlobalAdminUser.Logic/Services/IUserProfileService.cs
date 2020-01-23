using BulbaCourses.GlobalAdminUser.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Logic.Services
{
    public interface IUserProfileService
    {
        Task<UserProfileDTO> GetByIdAsync(string id);
        void Update(UserProfileDTO user);
    }
}
