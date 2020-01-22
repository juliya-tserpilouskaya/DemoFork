using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ICourseCategoryServiceDb
    {
        Task<IEnumerable<CourseCategoryDb>> GetAllAsync();
        Task<CourseCategoryDb> GetByIdAsync(string id);
        Task<Result<CourseCategoryDb>> AddAsync(CourseCategoryDb courseCategoryDb);
        Task <Result<CourseCategoryDb>> DeleteAsync(CourseCategoryDb courseCategoryDb);
        Task<Result<CourseCategoryDb>> DeleteByIdAsync(string id);
        Task<Result<CourseCategoryDb>> UpdateAsync(CourseCategoryDb courseCategoryDb);
    }
}
