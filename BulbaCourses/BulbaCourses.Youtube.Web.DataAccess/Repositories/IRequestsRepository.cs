using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IRequestsRepository
    {
        List<SearchRequest> SearchRequests { get; }

        SearchRequest SaveRequest(SearchRequest request);

        SearchRequest DeleteRequest(string requestId);

        IEnumerable<SearchRequest> GetAllRequests();

        SearchRequest GetRequestById(string requestId);
    }
}