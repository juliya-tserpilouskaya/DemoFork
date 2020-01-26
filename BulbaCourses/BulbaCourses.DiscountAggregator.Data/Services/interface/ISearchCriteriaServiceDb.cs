using System.Collections.Generic;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ISearchCriteriaServiceDb
    {
        Task<Result<SearchCriteriaDb>> AddAsync(SearchCriteriaDb criteria);
        Task<Result<SearchCriteriaDb>> DeleteAsync(SearchCriteriaDb criteria);
        Task<IEnumerable<SearchCriteriaDb>> GetAllAsync();
        Task<SearchCriteriaDb> GetByIdAsync(string id);
        Task<SearchCriteriaDb> GetByUserIdAsync(string userId);
        Task<Result<SearchCriteriaDb>> UpdateAsync(SearchCriteriaDb criteria);
    }
}