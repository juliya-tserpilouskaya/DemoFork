using BulbaCourses.Video.Data.DatabaseContext;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
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
