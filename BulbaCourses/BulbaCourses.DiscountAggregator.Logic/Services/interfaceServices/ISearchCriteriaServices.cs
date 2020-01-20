using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ISearchCriteriaServices
    {
        Task<IEnumerable<SearchCriteria>> GetAllAsync();
        Task<SearchCriteria> GetByIdAsync(string userId);
        Task<SearchCriteria> AddAsync(SearchCriteria searchCriteria);
        Task<SearchCriteria> UpdateAsync(SearchCriteria searchCriteria);
        Task<SearchCriteria> DeleteByIdAsync(string id);
    }
}