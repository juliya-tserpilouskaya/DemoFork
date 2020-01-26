using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface IUserService : IBaseService<UserLogic>
    {
        Task<Result> AddAsync(UserLogic user, UserLogic userY);

        Task<bool> ExistsNameAsync(string name);

        Task<Result<UserLogic>> GetByIdAsync(string Id);

        Task<Result<IEnumerable<UserLogic>>> GetAllAsync(string filter);

        Task<Result<IEnumerable<UserLogic>>> SearchAsync(string Name);

        Task<bool> ExistsIdAsync(string id);
    }
}
