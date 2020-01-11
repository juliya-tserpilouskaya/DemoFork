using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Services
{
    public interface IVideoService
    {
        /// <summary>
        /// Save ResultVideo
        /// </summary>
        /// <param name="video"></param>
        ResultVideo Save(ResultVideo video);

        /// <summary>
        /// Get all video
        /// </summary>
        /// <returns></returns>
        IEnumerable<ResultVideo> GetAll();

        /// <summary>
        /// Get video by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResultVideo GetById(string id);
    }
}
