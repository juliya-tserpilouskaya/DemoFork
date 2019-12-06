using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video.Data.Models;

namespace BulbaCourse.Video.Data.Interfaces
{
    public interface IVideoRepository
    {
        VideoMaterialDb GetById(string videoId);
        IEnumerable<VideoMaterialDb> GetAll();
        void Add(VideoMaterialDb video);
        void Update(VideoMaterialDb video);
        void Remove(VideoMaterialDb video);
    }
}
