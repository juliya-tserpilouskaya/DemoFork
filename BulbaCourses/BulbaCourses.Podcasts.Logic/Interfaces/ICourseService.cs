using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Interfaces
{
    public interface ICourseService
    {
        Task<Result> Add(CourseLogic course);

        Task<Result> AddFileToCourse(string Id, AudioLogic audio);

        Task<Result<CourseLogic>> GetById(string Id);

        Task<Result<CourseLogic>> GetByName(string courseName);

        Task<Result<IEnumerable<CourseLogic>>> GetAll();

        Task<Result> Delete(CourseLogic course);

        Task<Result> Update(CourseLogic course);
        
        bool Exists(string name);
    }
}
