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
        Task<Result> Add(CourseLogic course);

        Task<bool> Exists(string name);

        Task<Result<IEnumerable<CourseLogic>>> GetAll();

        Task<Result<IEnumerable<CourseLogic>>> Search(string Name);
    }
}
