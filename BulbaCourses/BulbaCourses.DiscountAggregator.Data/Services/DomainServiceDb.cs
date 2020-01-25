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
    public class DomainServiceDb : IDomainServiceDb
    {
        private readonly DAContext context;

        public DomainServiceDb(DAContext context)
        {
            this.context = context;
        }

        public async Task<Result<DomainDb>> AddAsync(DomainDb domain)
        {
            try
            {
                context.Domains.Add(domain);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<DomainDb>.Ok(domain);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<DomainDb>)Result<DomainDb>.Fail<DomainDb>($"Cannot save domain. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<DomainDb>)Result<DomainDb>.Fail<DomainDb>($"Cannot save domain. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<DomainDb>)Result<DomainDb>.Fail<DomainDb>($"Invalid domain. {e.Message}");
            }

        }

        public async Task<IEnumerable<DomainDb>> GetAllAsync()
        {
            var domainList = await context.Domains.ToListAsync().ConfigureAwait(false);
            return domainList.AsReadOnly();
        }

        public async Task<DomainDb> GetByIdAsync(string id)
        {
            var domain = await context.Domains.SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return domain;
        }

        public async Task<Result<DomainDb>> DeleteAsync(DomainDb domainDb)
        {
            try
            {
                context.Domains.Remove(domainDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<DomainDb>.Ok(domainDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<DomainDb>.Fail<DomainDb>($"Domain not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<DomainDb>.Fail<DomainDb>($"Invalid domain. {e.Message}");
            }

        }

        public async Task<Result<DomainDb>> DeleteByIdAsync(string id)
        {
            try
            {
                var domainDb = context.Domains.SingleOrDefault(c => c.Id.Equals(id));
                context.Domains.Remove(domainDb);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<DomainDb>.Ok(domainDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Result<DomainDb>.Fail<DomainDb>($"Domain not deleted. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return Result<DomainDb>.Fail<DomainDb>($"Invalid domain. {e.Message}");
            }
        }

        public async Task<Result<DomainDb>> UpdateAsync(DomainDb domainDb)
        {
            try
            {
                if (domainDb == null)
                {
                    throw new ArgumentNullException("domain");
                }
                context.Entry(domainDb).State = EntityState.Modified;
                await context.SaveChangesAsync().ConfigureAwait(false);
                return Result<CourseDb>.Ok(domainDb);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<DomainDb>)Result<DomainDb>.Fail<DomainDb>($"Cannot save domain. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<DomainDb>)Result<DomainDb>.Fail<DomainDb>($"Invalid domain. {e.Message}");
            }


        }
    }
}
