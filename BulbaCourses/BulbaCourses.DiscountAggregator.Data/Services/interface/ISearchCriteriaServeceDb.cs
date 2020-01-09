using System.Collections.Generic;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface ISearchCriteriaServeceDb
    {
        void Add(SearchCriteriaDb criteria);
        void Delete(SearchCriteriaDb criteria);
        IEnumerable<SearchCriteriaDb> GetAll();
        SearchCriteriaDb GetById(string id);
        void Update(SearchCriteriaDb criteria);
    }
}