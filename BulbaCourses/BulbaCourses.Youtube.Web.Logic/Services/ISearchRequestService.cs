using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
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
        /// Сheck if record of searchRequest exists in database
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        bool Exists(SearchRequestDb searchRequest);

    }
}
