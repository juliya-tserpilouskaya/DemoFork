using System.Collections.Generic;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IDomainServiceDb
    {
        Task<IEnumerable<DomainDb>> GetAllAsync();
        Task<DomainDb> GetByIdAsync(string id);
        Task<DomainDb> AddAsync(DomainDb courseCategoryDb);
        Task DeleteAsync(DomainDb courseCategoryDb);
        Task DeleteByIdAsync(string id);
        Task<DomainDb> UpdateAsync(DomainDb courseCategoryDb);
    }
}