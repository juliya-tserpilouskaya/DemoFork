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
        Task<Result> AddAsync(UserLogic user);

        Task<bool> ExistsAsync(string name);

        Task<Result<IEnumerable<UserLogic>>> GetAllAsync();

        Task<Result<IEnumerable<UserLogic>>> SearchAsync(string Name);
    }
}
