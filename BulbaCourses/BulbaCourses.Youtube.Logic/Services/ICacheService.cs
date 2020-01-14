using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface ICacheService
    {
        /// <summary>
        /// Get cache search request by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ResultVideo> GetValue(string id);

        /// <summary>
        /// Add search request to cache
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Add(string key, List<ResultVideo> value);

        /// <summary>
        /// Update search request upon repeated request
        /// </summary>
        /// <param name="value"></param>
        void Update(string key, List<ResultVideo> value);

        /// <summary>
        /// Delete cache of search request by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);
    }
}
