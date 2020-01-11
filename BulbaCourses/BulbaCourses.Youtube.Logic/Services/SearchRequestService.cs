using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.DataAccess.Repositories;
using BulbaCourses.Youtube.Logic.Models;
using FluentValidation;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class SearchRequestService : ISearchRequestService
    {
        ISearchRequestsRepository _searchRequestRepository;
        readonly IMapper _mapper;
        private readonly IValidator<SearchRequest> _validator;

        public SearchRequestService(ISearchRequestsRepository searchRequestRepository, 
            IMapper mapper, IValidator<SearchRequest> validator)
        {
            _searchRequestRepository = searchRequestRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public SearchRequest Save(SearchRequest searchRequest)
        {
            var result = _validator.Validate(searchRequest , ruleSet: "AddRequest, default");
            if (!result.IsValid)
                return searchRequest;

            var searchRequestDb = _mapper.Map<SearchRequestDb>(searchRequest);
            return _mapper.Map<SearchRequest>(_searchRequestRepository.SaveRequest(searchRequestDb));
        }

        public async Task<Result<SearchRequest>> SaveAsync(SearchRequest searchRequest)
        {
            //validation
            var result = _validator.Validate(searchRequest, ruleSet: "AddRequest, default");
            if (!result.IsValid)
                return (Result<SearchRequest>)Result.Fail($"Invalid model");


            var searchRequestDb = _mapper.Map<SearchRequestDb>(searchRequest);
            _searchRequestRepository.SaveRequest(searchRequestDb);

            try
            {
                await _searchRequestRepository.SaveChangeAsync();
                return Result<SearchRequest>.Ok(_mapper.Map<SearchRequest>(searchRequestDb));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return (Result<SearchRequest>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return (Result<SearchRequest>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbEntityValidationException ex)
            {
                return (Result<SearchRequest>)Result.Fail($"Cannot save model. Invalid model. {ex.Message}");
            }
        }

        public SearchRequest Update(SearchRequest searchRequest)
        {
            var result = _validator.Validate(searchRequest, ruleSet: "default");
            if (!result.IsValid)
                return searchRequest;

            var searchRequestDb = _mapper.Map<SearchRequestDb>(searchRequest);

            return _mapper.Map<SearchRequest>(_searchRequestRepository.Update(searchRequestDb));
        }

        public async Task<Result<SearchRequest>> UpdateAsync(SearchRequest searchRequest)
        {
            //validation
            var result = _validator.Validate(searchRequest, ruleSet: "default");
            if (!result.IsValid)
                return (Result<SearchRequest>)Result.Fail($"Invalid model");


            var searchRequestDb = _mapper.Map<SearchRequestDb>(searchRequest);
            _searchRequestRepository.Update(searchRequestDb);

            try
            {
                await _searchRequestRepository.SaveChangeAsync();
                return Result<SearchRequest>.Ok(_mapper.Map<SearchRequest>(searchRequestDb));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return (Result<SearchRequest>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return (Result<SearchRequest>)Result.Fail($"Cannot save model. {ex.Message}");
            }
            catch (DbEntityValidationException ex)
            {
                return (Result<SearchRequest>)Result.Fail($"Cannot save model. Invalid model. {ex.Message}");
            }
        }

        public bool Exists(SearchRequest searchRequest)
        {
            var searchRequestDb = _mapper.Map<SearchRequestDb>(searchRequest);
            return _searchRequestRepository.Exists(searchRequestDb);
        }

        public SearchRequest GetRequestByCacheId(string cacheId)
        {
            return _mapper.Map<SearchRequest>(_searchRequestRepository.GetRequestByCacheId(cacheId));
        }

        public async Task<SearchRequest> GetRequestByCacheIdAsync(string cacheId)
        {
            return _mapper.Map<SearchRequest>(await _searchRequestRepository.GetRequestByCacheIdAsync(cacheId));
        }

    }
}
