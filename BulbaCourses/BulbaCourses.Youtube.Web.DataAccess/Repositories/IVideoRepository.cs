using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public interface IVideoRepository : IDisposable
    {
        IEnumerable<ResultVideoDb> GetAll();
        ResultVideoDb GetById(int? id);
        void Create(ResultVideoDb video);
        void Update(ResultVideoDb video);
        void Delete(int? id);
        void Save();
    }
}