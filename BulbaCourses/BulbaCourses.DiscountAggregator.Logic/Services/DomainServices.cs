using AutoMapper;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.DiscountAggregator.Data.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class DomainServices : IDomainServices
    {
        private readonly IMapper _mapper;
        private readonly IDomainServiceDb _domains;

        public DomainServices(IMapper mapper, IDomainServiceDb domains)
        {
            this._mapper = mapper;
            _domains = domains;
        }

        public async Task<Result<Domain>> AddAsync(Domain domain)
        {
            var domainDb = _mapper.Map<Domain, DomainDb>(domain);

            try
            {
                await _domains.AddAsync(domainDb);
                return Result<DomainDb>.Ok(_mapper.Map<Domain>(domainDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Domain>)Result.Fail($"Cannot save domain. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<Domain>)Result.Fail($"Cannot save domain. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Domain>)Result.Fail($"Invalid domain. {e.Message}");
            }
        }

        public Task<Result> DeleteByIdAsync(string id)
        {
            _domains.DeleteByIdAsync(id);
            return Task.FromResult(Result.Ok());
        }

        public async Task<IEnumerable<Domain>> GetAllAsync()
        {
            var domains = await _domains.GetAllAsync();
            var result = _mapper.Map<IEnumerable<DomainDb>, IEnumerable<Domain>>(domains);
            return result;
        }

        public async Task<Domain> GetByIdAsync(string id)
        {
            var domains = await _domains.GetByIdAsync(id);
            var result = _mapper.Map<DomainDb, Domain>(domains);
            return result;
        }

        public async Task<Result<Domain>> UpdateAsync(Domain domain)
        {
            var domainDb = _mapper.Map<Domain, DomainDb>(domain);
            try
            {
                await _domains.UpdateAsync(domainDb);
                return Result<DomainDb>.Ok(_mapper.Map<Domain>(domainDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<Domain>)Result.Fail($"Cannot save domain. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<Domain>)Result.Fail($"Cannot save domain. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<Domain>)Result.Fail($"Invalid domain. {e.Message}");
            }
        }
    }
}
