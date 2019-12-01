using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using Video = BulbaCourses.Youtube.Web.DataAccess.Models.Video;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class VideoService : IVideoService
    {
        IVideoRepository _videoRepository;
        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public VideoService()
        {
            _videoRepository = new VideoRepository();
        }

        public IEnumerable<Video> GetAll()
        {
            return _videoRepository.GetAll();
        }

        public Video GetById(int? id)
        {
            return _videoRepository.GetById(id);
        }
    }
}
