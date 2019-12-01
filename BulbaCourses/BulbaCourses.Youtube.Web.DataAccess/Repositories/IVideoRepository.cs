using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IVideoRepository : IDisposable
    {
        IEnumerable<Video> GetAll();
        Video GetById(int? id);
        void Create(Video video);
        void Update(Video video);
        void Delete(int? id);
        void Save();
    }
}