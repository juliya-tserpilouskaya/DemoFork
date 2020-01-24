using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ISearchCriteriaServices
    {
        Task<IEnumerable<SearchCriteria>> GetAllAsync();
        Task<SearchCriteria> GetByIdAsync(string id);
        Task<SearchCriteria> GetByUserIdAsync(string userId);
        Task<Result<SearchCriteria>> AddAsync(SearchCriteria searchCriteria);
        Task<Result<SearchCriteria>> UpdateAsync(SearchCriteria searchCriteria);
        Task<Result<SearchCriteria>> DeleteByIdAsync(string id);
    }
}