using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface ISearchRequestService
    {
        /// <summary>
        /// Save search request
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        SearchRequest Save(SearchRequest searchRequest);

        Task<Result<SearchRequest>> SaveAsync(SearchRequest story);

        /// <summary>
        /// Update search request
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        SearchRequest Update(SearchRequest searchRequest);

        Task<Result<SearchRequest>> UpdateAsync(SearchRequest story);

        /// <summary>
        /// Сheck if record of searchRequest exists in database
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        bool Exists(SearchRequest searchRequest);

        /// <summary>
        /// Get SearchRequest by CacheId
        /// </summary>
        /// <param name="cacheId"></param>
        /// <returns></returns>
        SearchRequest GetRequestByCacheId(string cacheId);

        /// <summary>
        /// Get SearchRequest by CacheId (Async method)
        /// </summary>
        /// <param name="cacheId"></param>
        /// <returns></returns>
        Task<SearchRequest> GetRequestByCacheIdAsync(string cacheId);

    }
}
