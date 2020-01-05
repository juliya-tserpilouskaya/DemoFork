using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface IVideoService
    {
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
        ResultVideoDb GetById(string id);
    }
}
