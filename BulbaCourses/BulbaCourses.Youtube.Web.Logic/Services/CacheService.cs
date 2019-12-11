using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.Logic.Models;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class CacheService
    {
        public SearchRequest GetValue(int? id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(id.ToString()) as SearchRequest;
        }

        public bool Add(SearchRequest value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

        public void Update(SearchRequest value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(value.Id.ToString(), value, DateTime.Now.AddMinutes(10));
        }

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
