using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.DataAccess.Repositories;
using BulbaCourses.Youtube.Logic.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class SearchRequestService : ISearchRequestService
    {
        ISearchRequestsRepository _searchRequestRepository;
        public SearchRequestService(ISearchRequestsRepository searchRequestRepository)
        {
            _searchRequestRepository = searchRequestRepository;
        }

        public SearchRequestDb Save(SearchRequestDb searchRequest)
        {
            return _searchRequestRepository.SaveRequest(searchRequest);
        }
        public void Update(SearchRequestDb searchRequest)
        {
            _searchRequestRepository.Update(searchRequest);
        }

        public bool Exists(SearchRequestDb searchRequest)
        {
            return _searchRequestRepository.Exists(searchRequest);
        }

        public SearchRequestDb GetRequestByCacheId(string cacheId)
        {
            return _searchRequestRepository.GetRequestByCacheId(cacheId);
        }

        public async Task<SearchRequestDb> GetRequestByCacheIdAsync(string cacheId)
        {
            return await _searchRequestRepository.GetRequestByCacheIdAsync(cacheId);
        }

    }
}
