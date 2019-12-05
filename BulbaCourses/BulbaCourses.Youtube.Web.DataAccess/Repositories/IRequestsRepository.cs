using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IRequestsRepository
    {
        IQueryable<SearchRequestDb> SearchRequests { get; }

        SearchRequestDb SaveRequest(SearchRequestDb request);

        SearchRequestDb DeleteRequest(string requestId);

        IEnumerable<SearchRequestDb> GetAllRequests();

        SearchRequestDb GetRequestById(string requestId);
    }
}