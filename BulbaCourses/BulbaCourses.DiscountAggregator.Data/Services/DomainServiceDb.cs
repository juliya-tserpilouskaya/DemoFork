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
        private readonly CourseContext context;

        public DomainServiceDb(CourseContext context)
        {
            this.context = context;
        }

        public void Add(DomainDb domain)
        {
            context.Domains.Add(domain);
            context.SaveChanges();
        }

        public IEnumerable<DomainDb> GetAll()
        {
            var domains = context.Domains.ToList().AsReadOnly();
            return domains;
        }

        public DomainDb GetById(string id)
        {
            var domain = context.Domains.FirstOrDefault(c => c.Id.Equals(id));
            return domain;
        }

        public void Delete(DomainDb domain)
        {
            context.Domains.Remove(domain);
            context.SaveChanges();
        }

        public void Update(DomainDb domain)
        {
            if (domain != null)
            {
                context.Entry(domain).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
