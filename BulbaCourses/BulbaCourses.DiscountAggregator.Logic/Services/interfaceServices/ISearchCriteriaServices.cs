using BulbaCourses.DiscountAggregator.Logic.Models;
using System.Collections.Generic;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    public interface ISearchCriteriaServices
    {
        SearchCriteria GetByUserId(string userId);
        IEnumerable<SearchCriteria> GetAll();
        SearchCriteria Add(SearchCriteria searchCriteria);
    }
}