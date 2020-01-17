using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public interface ISearchRequestsRepository : IDisposable
    {
        Task SaveChangeAsync();
        SearchRequestDb SaveRequest(SearchRequestDb request);
        SearchRequestDb Update(SearchRequestDb request);
        void DeleteRequest(int? requestId);
        IEnumerable<SearchRequestDb> GetAllRequests();
        Task<IEnumerable<SearchRequestDb>> GetAllRequestsAsync();
        SearchRequestDb GetRequestByCacheId(string cacheId);

        Task<SearchRequestDb> GetRequestByCacheIdAsync(string cacheId);
        bool Exists(SearchRequestDb searchRequest);

    }
}