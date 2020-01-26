using AutoMapper;
using BulbaCourses.DiscountAggregator.Data.Models;
using BulbaCourses.DiscountAggregator.Data.Services;
using BulbaCourses.DiscountAggregator.Infrastructure.Models;
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

        public async Task<SearchCriteria> GetByUserIdAsync(string userId)
        {
            var criteria = await _criteriaServiceDb.GetByUserIdAsync(userId);
            var result = _mapper.Map<SearchCriteriaDb, SearchCriteria>(criteria);
            return result;
        }

        public async Task<Result<SearchCriteria>> AddAsync(SearchCriteria criteria)
        {
            criteria.Id = Guid.NewGuid().ToString();
            var criteriaDb = _mapper.Map<SearchCriteria, SearchCriteriaDb>(criteria);
            var result = await _criteriaServiceDb.AddAsync(criteriaDb);
            return result.IsSuccess ? Result<SearchCriteria>.Ok(_mapper.Map<SearchCriteria>(result.Data))
                : (Result<SearchCriteria>)Result.Fail(result.Message);
        }
        
        public async Task<Result<SearchCriteria>> UpdateAsync(SearchCriteria criteria)
        {
            var criteriaDb = _mapper.Map<SearchCriteria, SearchCriteriaDb>(criteria);
            var result = await _criteriaServiceDb.UpdateAsync(criteriaDb);
            return result.IsSuccess ? Result<SearchCriteria>.Ok(_mapper.Map<SearchCriteria>(result.Data))
                : (Result<SearchCriteria>)Result.Fail(result.Message);
        }    

        public async Task<Result<SearchCriteria>> DeleteByIdAsync(string idCriteria)
        {
            var criteriaDb = _criteriaServiceDb.GetByIdAsync(idCriteria);
            var result = await _criteriaServiceDb.DeleteAsync(criteriaDb.Result);
            return result.IsSuccess ? Result<SearchCriteria>.Ok(_mapper.Map<SearchCriteria>(result.Data))
                : (Result<SearchCriteria>)Result.Fail(result.Message);
        }

    }
}
