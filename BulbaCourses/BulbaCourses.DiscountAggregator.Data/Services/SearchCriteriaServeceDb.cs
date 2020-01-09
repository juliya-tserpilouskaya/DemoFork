using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class SearchCriteriaServeceDb
    {
        private readonly CourseContext context;

        public SearchCriteriaServeceDb(CourseContext context)
        {
            this.context = context;
        }

        public void Add(SearchCriteriaDb criteria)
        {
            context.SearchCriterias.Add(criteria);
            context.SaveChanges();
        }

        public IEnumerable<SearchCriteriaDb> GetAll()
        {
            var criterias = context.SearchCriterias.ToList().AsReadOnly();
            return criterias;
        }

        public SearchCriteriaDb GetById(string id)
        {
            var criteria = context.SearchCriterias.FirstOrDefault(c => c.Id.Equals(id));
            return criteria;
        }

        public void Delete(SearchCriteriaDb criteria)
        {
            context.SearchCriterias.Remove(criteria);
            context.SaveChanges();
        }

        public void Update(SearchCriteriaDb criteria)
        {
            if (criteria != null)
            {
                context.Entry(criteria).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
