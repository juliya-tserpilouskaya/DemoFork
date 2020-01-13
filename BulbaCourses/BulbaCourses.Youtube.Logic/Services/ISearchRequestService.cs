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
        SearchRequestDb Save(SearchRequestDb searchRequest);
        /// <summary>
        /// Update search request
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        void Update(SearchRequestDb searchRequest);

        /// <summary>
        /// Сheck if record of searchRequest exists in database
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        bool Exists(SearchRequestDb searchRequest);
        /// <summary>
        /// Get SearchRequest by CacheId
        /// </summary>
        /// <param name="cacheId"></param>
        /// <returns></returns>
        SearchRequestDb GetRequestByCacheId(string cacheId);
        /// <summary>
        /// Get SearchRequest by CacheId (Async method)
        /// </summary>
        /// <param name="cacheId"></param>
        /// <returns></returns>
        Task<SearchRequestDb> GetRequestByCacheIdAsync(string cacheId);

    }
}
