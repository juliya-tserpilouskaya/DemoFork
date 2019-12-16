using BulbaCourses.Video.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Interfaces
{
    public interface IVideoRepository : IDisposable
    {
        VideoMaterialDb GetById(string videoId);
        IEnumerable<VideoMaterialDb> GetAll();
        void Add(VideoMaterialDb video);
        void Update(VideoMaterialDb video);
        void Remove(VideoMaterialDb video);

        Task<VideoMaterialDb> GetByIdAsync(string videoId);
        Task<IEnumerable<VideoMaterialDb>> GetAllAsync();
        Task<int> AddAsync(VideoMaterialDb videoDb);
        Task<int> UpdateAsync(VideoMaterialDb videoDb);
        Task<int> RemoveAsync(VideoMaterialDb video);
    }
}
