using BulbaCourses.Video.Logic.Models;
using BulbaCourses.Video.Logic.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Logic.InterfaceServices
{
    public interface IVideoService
    {
        VideoMaterialInfo GetById(string videoId);
        IEnumerable<VideoMaterialInfo> GetAll();
        void Add(VideoMaterialInfo video);
        void Update(VideoMaterialInfo video);
        void Delete(VideoMaterialInfo video);
        void DeleteById(string videoId);

        Task<VideoMaterialInfo> GetByIdAsync(string videoId);
        Task<IEnumerable<VideoMaterialInfo>> GetAllAsync();
        Task<Result<VideoMaterialInfo>> UpdateAsync(VideoMaterialInfo video);
        Task<Result<VideoMaterialInfo>> AddAsync(VideoMaterialInfo video);
        Task<Result> DeleteByIdAsync(string videoId);

        Task<Result> AddComment(VideoMaterialInfo video, string comment);
    }
}
