using System.Collections.Generic;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IDomainServiceDb
    {
        void Add(DomainDb domain);
        void Delete(DomainDb domain);
        IEnumerable<DomainDb> GetAll();
        DomainDb GetById(string id);
        void Update(DomainDb domain);
    }
}