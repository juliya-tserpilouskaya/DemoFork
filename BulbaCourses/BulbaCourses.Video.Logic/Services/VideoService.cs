using AutoMapper;
using BulbaCourses.Video.Data.Interfaces;
using BulbaCourses.Video.Data.Models;
using BulbaCourses.Video.Logic.InterfaceServices;
using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.Services
{
    /// <summary>
    /// Provides a mechanism for working with Videos.
    /// </summary>
    public class VideoService : IVideoService
    {
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;

        /// <summary>
        /// Creates a new video service.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="videoRepository"></param>
        public VideoService(IMapper mapper, IVideoRepository videoRepository)
        {
            _mapper = mapper;
            _videoRepository = videoRepository;
        }
        /// <summary>
        /// Create a new video.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public void Add(VideoMaterialInfo video)
        {
            var videoDb = _mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            _videoRepository.Add(videoDb);
        }

        /// <summary>
        /// Create a new video.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task<Result<VideoMaterialInfo>> AddAsync(VideoMaterialInfo video, string courseId)
        {
            var videoDb = _mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            videoDb.Created = DateTime.Now;
            videoDb.CourseId = courseId; //заменить на ID курса
            try
            {
                await _videoRepository.AddAsync(videoDb);
                return Result<VideoMaterialInfo>.Ok(_mapper.Map<VideoMaterialInfo>(videoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<VideoMaterialInfo>)Result.Fail($"Cannot save video. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<VideoMaterialInfo>)Result.Fail($"Cannot save video. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<VideoMaterialInfo>)Result.Fail($"Invalid video. {e.Message}");
            }
        }

        /// <summary>
        /// Remove video.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public void Delete(VideoMaterialInfo video)
        {
            var videoDb = _mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            _videoRepository.Remove(videoDb);
        }

        /// <summary>
        /// Remove video by id.
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public void DeleteById(string videoId)
        {
            var video = _videoRepository.GetById(videoId);
            _videoRepository.Remove(video);
        }

        /// <summary>
        /// Remove video by id.
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public Task<Result> DeleteByIdAsync(string videoId)
        {
            _videoRepository.RemoveAsyncById(videoId);
            return Task.FromResult(Result.Ok());
        }

        /// <summary>
        /// Gets all videos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VideoMaterialInfo> GetAll()
        {
            var videos = _videoRepository.GetAll();
            var result = _mapper.Map<IEnumerable<VideoMaterialDb>, IEnumerable<VideoMaterialInfo>>(videos);
            return result;
        }

        /// <summary>
        /// Gets all videos.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VideoMaterialInfo>> GetAllAsync()
        {
            var videos = await _videoRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<VideoMaterialDb>, IEnumerable<VideoMaterialInfo>>(videos);
            return result;
        }

        /// <summary>
        /// Show video details by id.
        /// </summary>
        /// /// <param name="videoId"></param>
        /// <returns></returns>
        public VideoMaterialInfo GetById(string videoId)
        {
            var video = _videoRepository.GetById(videoId);
            var videoInfo = _mapper.Map<VideoMaterialDb, VideoMaterialInfo>(video);
            return videoInfo;
        }

        /// <summary>
        /// Show video details by id.
        /// </summary>
        /// /// <param name="videoId"></param>
        /// <returns></returns>
        public async Task<VideoMaterialInfo> GetByIdAsync(string videoId)
        {
            var video = await _videoRepository.GetByIdAsync(videoId);
            var videoInfo = _mapper.Map<VideoMaterialDb, VideoMaterialInfo>(video);
            return videoInfo;
        }

        /// <summary>
        /// Update video.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public void Update(VideoMaterialInfo video)
        {
            var videoDb = _mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            _videoRepository.Update(videoDb);
        }

        /// <summary>
        /// Update video.
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public async Task<Result<VideoMaterialInfo>> UpdateAsync(VideoMaterialInfo video)
        {
            var videoDb = _mapper.Map<VideoMaterialInfo, VideoMaterialDb>(video);
            try
            {
                await _videoRepository.UpdateAsync(videoDb);
                return Result<VideoMaterialInfo>.Ok(_mapper.Map<VideoMaterialInfo>(videoDb));
            }
            catch (DbUpdateConcurrencyException e)
            {
                return (Result<VideoMaterialInfo>)Result.Fail($"Cannot update video. {e.Message}");
            }
            catch (DbUpdateException e)
            {
                return (Result<VideoMaterialInfo>)Result.Fail($"Cannot update video. Duplicate field. {e.Message}");
            }
            catch (DbEntityValidationException e)
            {
                return (Result<VideoMaterialInfo>)Result.Fail($"Invalid video. {e.Message}");
            }
        }

        /// <summary>
        /// Add new comment to video.
        /// </summary>
        /// <param name="video"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public Task<Result> AddComment(string videoId, string userId, string comment)
        {
            var videoDb = _videoRepository.GetById(videoId);
            var commentDb = new CommentDb() { 
                CommentId = Guid.NewGuid().ToString(), 
                Date = DateTime.Now, 
                Text = comment, 
                VideoId = videoDb
            };
            try
            {
                _videoRepository.AddComment(userId, commentDb);
                return Task.FromResult(Result.Ok());
            }
            catch (DbUpdateConcurrencyException e)
            {
                return Task.FromResult(Result.Fail($"Cannot add comment to video. {e.Message}"));
            }
            catch (DbUpdateException e)
            {
                return Task.FromResult(Result.Fail($"Cannot add comment to video. Duplicate field. {e.Message}"));
            }
            catch (DbEntityValidationException e)
            {
                return Task.FromResult(Result.Fail($"Invalid tag. {e.Message}"));
            }
        }
    }
}
