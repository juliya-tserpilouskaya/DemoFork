using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface ICacheService
    {
        /// <summary>
        /// Get cache search request by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SearchRequestDb GetValue(int? id);

        /// <summary>
        /// Add search request to cache
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Add(SearchRequestDb value);

        /// <summary>
        /// Update search request upon repeated request
        /// </summary>
        /// <param name="value"></param>
        void Update(SearchRequestDb value);

        /// <summary>
        /// Delete cache of search request by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
