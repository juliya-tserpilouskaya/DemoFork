using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IVideoRepository : IDisposable
    {
        IEnumerable<VideoDb> GetAll();
        VideoDb GetById(int? id);
        void Create(VideoDb video);
        void Update(VideoDb video);
        void Delete(int? id);
        void Save();
    }
}