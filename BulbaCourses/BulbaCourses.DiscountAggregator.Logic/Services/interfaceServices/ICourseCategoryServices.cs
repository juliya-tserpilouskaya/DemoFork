using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ICourseCategoryServices
    {
        Task<IEnumerable<CourseCategory>> GetAllAsync();
        Task<CourseCategory> GetByIdAsync(string id);
        Task<Result<CourseCategory>> AddAsync(CourseCategory course);
        Task<Result<CourseCategory>> DeleteByIdAsync(string id);
        Task<Result<CourseCategory>> UpdateAsync(CourseCategory course);
    }
}
