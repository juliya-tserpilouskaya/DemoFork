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
        /// YouTube video search
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        IEnumerable<ResultVideoDb> SearchRun(SearchRequest searchRequest);
    }
}
