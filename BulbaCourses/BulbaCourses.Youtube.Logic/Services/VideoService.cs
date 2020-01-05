using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Repositories;
using BulbaCourses.Youtube.Logic.Models;
using BulbaCourses.Youtube.DataAccess.Models;
using ResultVideoDb = BulbaCourses.Youtube.DataAccess.Models.ResultVideoDb;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class VideoService : IVideoService
    {
        IVideoRepository _videoRepository;
        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        /// <summary>
        /// Get all video from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ResultVideoDb> GetAll()
        {
            return _videoRepository.GetAll();
        }

        /// <summary>
        /// Get video by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultVideoDb GetById(string id)
        {
            return _videoRepository.GetById(id);
        }
    }
}
