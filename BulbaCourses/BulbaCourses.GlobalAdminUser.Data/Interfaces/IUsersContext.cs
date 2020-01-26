using BulbaCourses.GlobalAdminUser.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Interfaces
{
    public interface IUsersContext
    {
        Task<IEnumerable<UserDb>> GetAll();
        Task<UserDb> GetById(string id);
        Task<string> RegisterUser(RegisterUserDb user);
        Task<bool> ChangePassword(UserChangePassword user);
        Task<bool> Remove(string id);
        Task<IEnumerable<RoleDb>> GetRoles();
    }
}