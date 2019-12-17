using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class SearchCriteriaServices : ISearchCriteriaServices
    {
        public SearchCriteria GetByUserId(string userId)
        {
            return SearchCriteriaStorage.GetByUserId(userId);
        }

        public IEnumerable<SearchCriteria> GetAll()
        {
            return SearchCriteriaStorage.GetAll();
        }

        public SearchCriteria Add(SearchCriteria searchCriteria)
        {
            return SearchCriteriaStorage.Add(searchCriteria);
        }
    }
}
