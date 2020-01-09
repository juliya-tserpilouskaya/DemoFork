using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface IVideoService
    {
        /// <summary>
        /// Get List response by search query
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        IEnumerable<string> GetSearchListResponse(string searchTerm);

        /// <summary>
        /// Get all video
        /// </summary>
        /// <returns></returns>
        IEnumerable<ResultVideoDb> GetAll();

        /// <summary>
        /// Get video by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultVideoDb GetById(int? id);

    }
}
