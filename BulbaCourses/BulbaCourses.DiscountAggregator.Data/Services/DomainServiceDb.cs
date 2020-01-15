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
        private readonly DAContext context;

        public DomainServiceDb(DAContext context)
        {
            this.context = context;
        }

        public async Task<DomainDb> AddAsync(DomainDb domain)
        {
            context.Domains.Add(domain);
            context.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return await Task.FromResult(domain);
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

        public async Task DeleteAsync(DomainDb domainDb)
        {
            context.Domains.Remove(domainDb);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var domain = context.Domains.SingleOrDefault(c => c.Id.Equals(id));
            context.Domains.Remove(domain);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<DomainDb> UpdateAsync(DomainDb domainDb)
        {
            if (domainDb == null)
            {
                throw new ArgumentNullException("domain");
            }
            context.Entry(domainDb).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(domainDb);
        }
    }
}
