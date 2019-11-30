using BulbaCourses.Youtube.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.Controllers
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Video> GetAll();
        Video GetById(int? id);
        void Create(Video video);
        void Update(Video video);
        void Delete(int? id);
        void Save();
    }
}