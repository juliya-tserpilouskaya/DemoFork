using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDb>> GetAllAsync();
        IEnumerable<CourseDb> GetAll();
        Task<CourseDb> GetByIdAsync(string id);
        Task<IEnumerable<CourseDb>> GetByIdUserAsync(string idUser);
        CourseDb GetById(string id);
        Task<Result<CourseDb>> AddAsync(CourseDb courseDb);
        Task <Result<CourseDb>> DeleteAsync(CourseDb courseDb);
        Task<Result<CourseDb>> DeleteByIdAsync(string id);
        Task<Result<CourseDb>> UpdateAsync(CourseDb courseDb);
    }
}
