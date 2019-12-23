using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using BulbaCourses.Youtube.Web.Logic.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace BulbaCourses.Youtube.Web.Logic.Services
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
        public bool Exists(SearchRequestDb searchRequest)
        {
            return _searchRequestRepository.Exists(searchRequest);
        }

    }
}
