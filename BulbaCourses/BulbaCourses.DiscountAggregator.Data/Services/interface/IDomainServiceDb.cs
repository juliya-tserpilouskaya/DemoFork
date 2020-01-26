using System.Collections.Generic;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;

namespace BulbaCourses.DiscountAggregator.Data.Services
{
    public interface IDomainServiceDb
    {
        Task<IEnumerable<DomainDb>> GetAllAsync();
        Task<DomainDb> GetByIdAsync(string id);
        Task<Result<DomainDb>> AddAsync(DomainDb courseCategoryDb);
        Task<Result<DomainDb>> DeleteAsync(DomainDb courseCategoryDb);
        Task<Result<DomainDb>> DeleteByIdAsync(string id);
        Task<Result<DomainDb>> UpdateAsync(DomainDb courseCategoryDb);
    }
}