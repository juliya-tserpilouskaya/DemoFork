using BulbaCourses.DiscountAggregator.Data.Context;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public class SearchCriteriaServiceDb : ISearchCriteriaServiceDb
    {
        private readonly DAContext context;

        public SearchCriteriaServiceDb(DAContext context)
        {
            this.context = context;
        }

        public async Task<Result<SearchCriteriaDb>> AddAsync(SearchCriteriaDb criteriaDb)
        {
            try 
            { 
                context.SearchCriterias.Add(criteriaDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<SearchCriteriaDb>.Ok(criteriaDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"Cannot save SearchCriteria. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"Cannot save SearchCriteria. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"Invalid SearchCriteria. {e.Message}");
            }
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

        public async Task<SearchCriteriaDb> GetByUserIdAsync(string userId)
        {
            var user = context.Profiles.Include(i => i.SearchCriteria).FirstOrDefault(p => p.Id == userId);
            var criteriaDb = await context.SearchCriterias
                .Include(c => c.Domains)
                .Include(v => v.CourseCategories)
                .SingleOrDefaultAsync(c => c.Id.Equals(user.SearchCriteria.Id)).ConfigureAwait(false);
            return criteriaDb;
        }

        public async Task<Result<SearchCriteriaDb>> UpdateAsync(SearchCriteriaDb criteriaDb)
        {
            try
            {
                context.Entry(criteriaDb).State = EntityState.Modified;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<SearchCriteriaDb>.Ok(criteriaDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"SearchCriteria not update. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"SearchCriteria not update. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"Invalid SearchCriteria. {e.Message}");
            }
        }

        public async Task<Result<SearchCriteriaDb>> DeleteAsync(SearchCriteriaDb criteriaDb)
        {
            try
            {
                context.SearchCriterias.Remove(criteriaDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<SearchCriteriaDb>.Ok(criteriaDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"SearchCriteria not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<SearchCriteriaDb>.Fail<SearchCriteriaDb>($"Invalid SearchCriteria. {e.Message}");
            }
        }
    }
}
