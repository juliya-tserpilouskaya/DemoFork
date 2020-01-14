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
    public class SearchCriteriaServiceDb : ISearchCriteriaServiceDb
    {
        private readonly CourseContext context;

        public SearchCriteriaServiceDb(CourseContext context)
        {
            this.context = context;
        }

        public async Task<SearchCriteriaDb> AddAsync(SearchCriteriaDb criteriaDb)
        {
            context.SearchCriterias.Add(criteriaDb);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return criteriaDb;
        }

        public async Task<IEnumerable<SearchCriteriaDb>> GetAllAsync()
        {
            var criterias = await context.SearchCriterias
                .Include(x => x.CourseCategories)
                .Include(c => c.Domains)
                .ToListAsync().ConfigureAwait(false);
            return criterias.AsReadOnly();
        }

        public async Task<SearchCriteriaDb> GetByIdAsync(string id)
        {
            var criteriaDb = await context.SearchCriterias
                .Include(c => c.Domains)
                .Include(v => v.CourseCategories)
                .SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return criteriaDb;
        }

        public async Task<SearchCriteriaDb> UpdateAsync(SearchCriteriaDb criteriaDb)
        {
            if (criteriaDb == null)
            {
                throw new ArgumentNullException("Criteria");
            }
            context.Entry(criteriaDb).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return criteriaDb;
        }

        public async Task<SearchCriteriaDb> DeleteAsync(SearchCriteriaDb criteriaDb)
        {
            context.SearchCriterias.Remove(criteriaDb);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return criteriaDb;
        }
    }
}
