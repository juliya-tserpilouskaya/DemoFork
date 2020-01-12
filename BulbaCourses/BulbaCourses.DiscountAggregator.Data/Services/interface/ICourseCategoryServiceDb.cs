using BulbaCourses.DiscountAggregator.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ICourseCategoryServiceDb
    {
        Task<IEnumerable<CourseCategoryDb>> GetAllAsync();
        Task<CourseCategoryDb> GetByIdAsync(string id);
        Task<CourseCategoryDb> AddAsync(CourseCategoryDb courseCategoryDb);
        Task DeleteAsync(CourseCategoryDb courseCategoryDb);
        Task DeleteByIdAsync(string id);
        Task<CourseCategoryDb> UpdateAsync(CourseCategoryDb courseCategoryDb);
    }
}
