using BulbaCourse.Video.Data.DatabaseContex;
using BulbaCourse.Video.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoDbContext videoDbContext;

        public VideoRepository(VideoDbContext videoDbContext)
        {
            this.videoDbContext = videoDbContext;
        }

        public void Add(VideoMaterialDb video)
        {
            videoDbContext.VideoMaterials.Add(video);
            videoDbContext.SaveChanges();
        }

        public IEnumerable<VideoMaterialDb> GetAll()
        {
            var videoList = videoDbContext.VideoMaterials.ToList().AsReadOnly();
            return videoList;
        }

        public VideoMaterialDb GetById(string videoId)
        {
            var video = videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            return video;
        }

        public void Remove(VideoMaterialDb video)
        {
            videoDbContext.VideoMaterials.Remove(video);
            videoDbContext.SaveChanges();
        }

        public void RemoveById(string videoId)
        {
            var deletedVideo = videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            Remove(deletedVideo);
        }

        public void Update(VideoMaterialDb video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            videoDbContext.Entry(video).State = EntityState.Modified;
            videoDbContext.SaveChanges();
        }
    }
}
