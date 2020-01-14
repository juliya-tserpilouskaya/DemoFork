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
    public class DomainServiceDb : IDomainServiceDb
    {
        private readonly CourseContext domainContext;

        public DomainServiceDb(CourseContext context)
        {
            this.domainContext = context;
        }

        public async Task<DomainDb> AddAsync(DomainDb domain)
        {
            domainContext.Domains.Add(domain);
            domainContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(domain);
        }

        public async Task<IEnumerable<DomainDb>> GetAllAsync()
        {
            var domainList = await domainContext.Domains.ToListAsync().ConfigureAwait(false);
            return domainList.AsReadOnly();
        }

        public async Task<DomainDb> GetByIdAsync(string id)
        {
            var domain = await domainContext.Domains.SingleOrDefaultAsync(c => c.Id.Equals(id)).ConfigureAwait(false);
            return domain;
        }

        public async Task DeleteAsync(DomainDb domainDb)
        {
            domainContext.Domains.Remove(domainDb);
            await domainContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var domain = domainContext.Domains.SingleOrDefault(c => c.Id.Equals(id));
            domainContext.Domains.Remove(domain);
            await domainContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<DomainDb> UpdateAsync(DomainDb domainDb)
        {
            if (domainDb == null)
            {
                throw new ArgumentNullException("domain");
            }
            domainContext.Entry(domainDb).State = EntityState.Modified;
            await domainContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(domainDb);
        }
    }
}
