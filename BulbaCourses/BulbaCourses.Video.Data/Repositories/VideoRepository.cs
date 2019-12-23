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
    public class VideoRepository : BaseRepository, IVideoRepository
    {
        public VideoRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        public void Add(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Add(video);
            _videoDbContext.SaveChanges();

        }

        public async Task<int> AddAsync(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Add(video);
            var result = await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return result;
        }

        public IEnumerable<VideoMaterialDb> GetAll()
        {
            var videoList = _videoDbContext.VideoMaterials.ToList().AsReadOnly();
            return videoList;

        }

        public async Task<IEnumerable<VideoMaterialDb>> GetAllAsync()
        {
            var videoList = await _videoDbContext.VideoMaterials.ToListAsync().ConfigureAwait(false);
            return videoList.AsReadOnly();
        }

        public VideoMaterialDb GetById(string videoId)
        {
            var video = _videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            return video;

        }

        public async Task<VideoMaterialDb> GetByIdAsync(string videoId)
        {
            var video = await _videoDbContext.VideoMaterials.SingleOrDefaultAsync(b => b.VideoId.Equals(videoId)).ConfigureAwait(false);
            return video;
        }

        public void Remove(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Remove(video);
            _videoDbContext.SaveChanges();

        }

        public async Task<int> RemoveAsync(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Remove(video);
            return await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(VideoMaterialDb video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            _videoDbContext.Entry(video).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        public async Task<int> UpdateAsync(VideoMaterialDb video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            _videoDbContext.Entry(video).State = EntityState.Modified;
            return await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
