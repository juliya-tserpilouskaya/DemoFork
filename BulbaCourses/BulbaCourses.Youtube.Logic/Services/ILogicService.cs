using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface ILogicService
    {
        /// <summary>
        /// YouTube video search
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        IEnumerable<ResultVideo> SearchRun(SearchRequest searchRequest, string user);

        /// <summary>
        /// YouTube video search
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        Task<IEnumerable<ResultVideo>> SearchRunAsync(SearchRequest searchRequest, string user);

    }
}