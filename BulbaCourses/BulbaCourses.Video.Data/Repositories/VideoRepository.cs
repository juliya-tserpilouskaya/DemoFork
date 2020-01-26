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
    /// <summary>
    /// Provides a mechanism for working video repository.
    /// </summary>
    public class VideoRepository : BaseRepository, IVideoRepository
    {
        public VideoRepository(VideoDbContext videoDbContext) : base(videoDbContext)
        {
        }

        /// <summary>
        /// Create a new video in repository.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public void Add(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Add(video);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Create a new video in repository.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task<VideoMaterialDb> AddAsync(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Add(video);
            _videoDbContext.SaveChangesAsync().ConfigureAwait(false).GetAwaiter();
            var result = await Task.FromResult(video);
            return result;
        }

        /// <summary>
        /// Gets all videos in repository.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VideoMaterialDb> GetAll()
        {
            var videoList = _videoDbContext.VideoMaterials.ToList().AsReadOnly();
            return videoList;

        }

        /// <summary>
        /// Gets all videos in repository.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VideoMaterialDb>> GetAllAsync()
        {
            var videoList = await _videoDbContext.VideoMaterials.ToListAsync().ConfigureAwait(false);
            return videoList.AsReadOnly();
        }

        /// <summary>
        /// Shows video details by id in repository.
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public VideoMaterialDb GetById(string videoId)
        {
            var video = _videoDbContext.VideoMaterials.FirstOrDefault(b => b.VideoId.Equals(videoId));
            return video;

        }

        /// <summary>
        /// Shows video details by id in repository.
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public async Task<VideoMaterialDb> GetByIdAsync(string videoId)
        {
            var video = await _videoDbContext.VideoMaterials.SingleOrDefaultAsync(b => b.VideoId.Equals(videoId)).ConfigureAwait(false);
            return video;
        }

        /// <summary>
        /// Remove video in repository.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public void Remove(VideoMaterialDb video)
        {
            _videoDbContext.VideoMaterials.Remove(video);
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Remove video in repository.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task RemoveAsync(VideoMaterialDb video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            _videoDbContext.VideoMaterials.Remove(video);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Remove video by id in repository.
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public async Task RemoveAsyncById(string videoId)
        {
            var video = _videoDbContext.VideoMaterials.SingleOrDefault(b => b.VideoId.Equals(videoId));
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            _videoDbContext.VideoMaterials.Remove(video);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Update video in repository.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public void Update(VideoMaterialDb video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            _videoDbContext.Entry(video).State = EntityState.Modified;
            _videoDbContext.SaveChanges();

        }

        /// <summary>
        /// Update video in repository.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task<VideoMaterialDb> UpdateAsync(VideoMaterialDb video)
        {
            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            _videoDbContext.Entry(video).State = EntityState.Modified;
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            return await Task.FromResult(video);
        }

        /// <summary>
        /// Add comment to video by user Id in repository.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="commentDb"></param>
        /// <returns></returns>
        public async Task<CommentDb> AddComment(string userId, CommentDb commentDb)
        {
            var user = _videoDbContext.Users.FirstOrDefault(c => c.UserId.Equals(userId));
            commentDb.UserId = user;
            _videoDbContext.Comments.Add(commentDb);
            await _videoDbContext.SaveChangesAsync().ConfigureAwait(false);
            var result = await Task.FromResult(commentDb);
            return result;
        }
    }
}
