using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        readonly IMapper _mapper;
        public VideoService(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Save ResultVideo
        /// </summary>
        /// <param name="video"></param>
        public ResultVideo Save(ResultVideo video)
        {
            var videoDb = _mapper.Map<ResultVideoDb>(video);
            return _mapper.Map<ResultVideo>(_videoRepository.Save(videoDb));
        }

        /// <summary>
        /// Get all video from repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ResultVideo> GetAll()
        {
            return _mapper.Map<IEnumerable<ResultVideo>>(_videoRepository.GetAll());
        }

        /// <summary>
        /// Get video by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResultVideo GetById(string id)
        {
            return _mapper.Map<ResultVideo>(_videoRepository.GetById(id));
        }
    }
}
