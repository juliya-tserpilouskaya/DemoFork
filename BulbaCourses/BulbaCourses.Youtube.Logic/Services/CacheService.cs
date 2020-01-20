using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class CacheService : ICacheService
    {
        /// <summary>
        /// Get query result from cache by searchrequestId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ResultVideo> GetValue(string id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(id) as List<ResultVideo>;
        }

        /// <summary>
        /// Add search request to cache
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(string key, List<ResultVideo> value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// Update cache for search request for refresh storage time
        /// </summary>
        /// <param name="value"></param>
        public void Update(string key, List<ResultVideo> value)
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
