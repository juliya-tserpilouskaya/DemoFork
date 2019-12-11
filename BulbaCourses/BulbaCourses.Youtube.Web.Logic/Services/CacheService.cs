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
        public SearchRequestDb GetValue(int? id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(id.ToString()) as SearchRequestDb;
        }

        /// <summary>
        /// Add search request to cache
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(SearchRequestDb value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// Update cache for search request for refresh storage time
        /// </summary>
        /// <param name="value"></param>
        public void Update(SearchRequestDb value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        /// <summary>
        /// Delete cache by searchrequestId
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(id.ToString()))
            {
                memoryCache.Remove(id.ToString());
            }
        }
    }
}
