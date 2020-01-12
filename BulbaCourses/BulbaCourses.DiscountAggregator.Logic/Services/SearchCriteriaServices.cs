using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Logic.Models.ModelsStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.DiscountAggregator.Logic.Services
{
    class SearchCriteriaServices : ISearchCriteriaServices
    {
        private readonly IMapper _mapper;
        private readonly ISearchCriteriaServiceDb _criteriaServiceDb;

        public SearchCriteriaServices(IMapper mapper, ISearchCriteriaServiceDb criteriaService)
        {
            this._mapper = mapper;
            _criteriaServiceDb = criteriaService;
        }
        public async Task<IEnumerable<SearchCriteria>> GetAllAsync()
        {
            var criterias = await _criteriaServiceDb.GetAllAsync();
            var result = _mapper.Map<IEnumerable<SearchCriteriaDb>, IEnumerable<SearchCriteria>>(criterias);
            return result;
        }

        public async Task<SearchCriteria> GetByIdAsync(string id)
        {
            var criteria = await _criteriaServiceDb.GetByIdAsync(id);
            var result = _mapper.Map<SearchCriteriaDb, SearchCriteria>(criteria);
            return result;
        }

        public Task<SearchCriteria> AddAsync(SearchCriteria criteria)
        {
            criteria.Id = Guid.NewGuid().ToString();
            var criteriaDb = _mapper.Map<SearchCriteria, SearchCriteriaDb>(criteria);
            _criteriaServiceDb.AddAsync(criteriaDb);
            return Task.FromResult(criteria);
        }

        public Task<SearchCriteria> UpdateAsync(SearchCriteria criteria)
        {
            var criteriaDb = _mapper.Map<SearchCriteria, SearchCriteriaDb>(criteria);
            _criteriaServiceDb.UpdateAsync(criteriaDb);
            return Task.FromResult(criteria);
        }    

        public Task<SearchCriteria> DeleteByIdAsync(string idCriteria)
        {
            var criteriaDb = _criteriaServiceDb.GetByIdAsync(idCriteria);
            _criteriaServiceDb.DeleteAsync(criteriaDb.Result);
            var criteria = _mapper.Map<SearchCriteriaDb, SearchCriteria>(criteriaDb.Result);
            return Task.FromResult(criteria);
        }

    }
}
