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
        Task<Result> AddAsync(CourseLogic course);

        Task<bool> ExistsAsync(string name);

        Task<Result<IEnumerable<CourseLogic>>> GetAllAsync();

        Task<Result<IEnumerable<CourseLogic>>> SearchAsync(string Name);
    }
}
