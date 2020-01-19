using BulbaCourses.GlobalAdminUser.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalAdminUser.Data.Context
{
    public interface IUsersContext
    {
        Task<IEnumerable<UserDb>> GetAll();
    }
}