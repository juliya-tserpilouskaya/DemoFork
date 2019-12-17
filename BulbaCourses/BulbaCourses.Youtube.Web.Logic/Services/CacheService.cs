using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class CacheService : ICacheService
    {
        /// <summary>
        /// Get query result from cache by searchrequestId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ResultVideoDb> GetValue(string id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(id) as List<ResultVideoDb>;
        }

        /// <summary>
        /// Add search request to cache
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(string key, List<ResultVideoDb> value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// Update cache for search request for refresh storage time
        /// </summary>
        /// <param name="value"></param>
        public void Update(string key, List<ResultVideoDb> value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(key, value, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// Delete cache by searchrequestId
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(id))
            {
                memoryCache.Remove(id);
            }
        }
    }
}
