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
using BulbaCourses.DiscountAggregator.Infrastructure.Models;

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
            domain.Id = Guid.NewGuid().ToString();
            var domainDb = _mapper.Map<Domain, DomainDb>(domain);
            var result = await _domains.AddAsync(domainDb);
            return result.IsSuccess ? Result<Domain>.Ok(_mapper.Map<Domain>(result.Data))
                : Result<Domain>.Fail<Domain>(result.Message);
        }

        public async Task<Result<Domain>> DeleteByIdAsync(string id)
        {
            var result = await _domains.DeleteByIdAsync(id);
            return result.IsSuccess ? Result<Domain>.Ok(_mapper.Map<Domain>(result.Data))
                : Result<Domain>.Fail<Domain>(result.Message);
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
            var result = await _domains.UpdateAsync(domainDb);
            return result.IsSuccess ? Result<Domain>.Ok(_mapper.Map<Domain>(result.Data))
            : Result<Domain>.Fail<Domain>(result.Message);
        }
    }
}
