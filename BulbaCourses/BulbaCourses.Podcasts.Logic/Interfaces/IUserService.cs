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
        Task<Result> Add(UserLogic user);

        Task<bool> Exists(string name);

        Task<Result<IEnumerable<UserLogic>>> GetAll();

        Task<Result<IEnumerable<UserLogic>>> Search(string Name);
    }
}
