using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface ILogicService
    {
        /// <summary>
        /// YouTube video search
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        IEnumerable<ResultVideo> SearchRun(SearchRequest searchRequest, User user);

        /// <summary>
        /// YouTube video search
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        Task<IEnumerable<ResultVideo>> SearchRunAsync(SearchRequest searchRequest, User user);

    }
}