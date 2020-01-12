using BulbaCourses.DiscountAggregator.Data.Models;
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
        CourseDb GetById(string id);
        Task<CourseDb> AddAsync(CourseDb courseDb);
        Task DeleteAsync(CourseDb courseDb);
        Task DeleteByIdAsync(string id);
        Task<CourseDb> UpdateAsync(CourseDb courseDb);
    }
}
