using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface ISearchRequestsRepository : IDisposable
    {
        SearchRequestDb SaveRequest(SearchRequestDb request);
        void DeleteRequest(int? requestId);
        IEnumerable<SearchRequestDb> GetAllRequests();
        SearchRequestDb GetRequestById(int? requestId);
    }
}