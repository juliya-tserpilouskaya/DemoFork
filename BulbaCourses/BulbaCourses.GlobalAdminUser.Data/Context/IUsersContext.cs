using BulbaCourses.GlobalAdminUser.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Context
{
    public interface IUsersContext
    {
        Task<IEnumerable<UserDb>> GetAll();
        Task<UserDb> GetById(string id);
        Task ChangePassword(UserChangePassword user);

        Task<IEnumerable<RoleDb>> GetRolesAsync();
    }
}