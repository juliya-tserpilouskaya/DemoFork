using System.Collections.Generic;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ISearchCriteriaServiceDb
    {
        Task<SearchCriteriaDb> AddAsync(SearchCriteriaDb criteria);
        Task<SearchCriteriaDb> DeleteAsync(SearchCriteriaDb criteria);
        Task<IEnumerable<SearchCriteriaDb>> GetAllAsync();
        Task<SearchCriteriaDb> GetByIdAsync(string id);
        Task<SearchCriteriaDb> UpdateAsync(SearchCriteriaDb criteria);
    }
}