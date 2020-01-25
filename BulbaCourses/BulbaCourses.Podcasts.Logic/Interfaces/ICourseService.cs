using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface ICourseService : IBaseService<CourseLogic>
    {
        Task<Result> AddAsync(CourseLogic course, UserLogic user);

        Task<bool> ExistsNameAsync(string name);

        Task<Result<CourseLogic>> GetByIdAsync(string Id);

        Task<Result<IEnumerable<CourseLogic>>> GetAllAsync(string filter);

        Task<Result<IEnumerable<CourseLogic>>> SearchAsync(string Name);

        Task<bool> ExistsIdAsync(string id);
        Task<Result> BuyAsync(CourseLogic courselogic, UserLogic userId);
    }
}
