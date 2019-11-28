using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.Models
{
    public interface IRequestsRepository
    {
        List<SearchRequest> SearchRequests { get; }

        void SaveRequest(SearchRequest request);

        SearchRequest DeleteRequest(int requestId);

        IEnumerable<SearchRequest> GetAllRequests;

        SearchRequest GetRequestById(int requestId);
    }
}