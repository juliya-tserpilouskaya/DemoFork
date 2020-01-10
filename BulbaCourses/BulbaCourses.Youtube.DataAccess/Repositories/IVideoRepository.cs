using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public interface IVideoRepository : IDisposable
    {        
        IEnumerable<ResultVideoDb> GetAll();
        Task<IEnumerable<ResultVideoDb>> GetAllAsync();
        ResultVideoDb GetById(string id);
        Task<ResultVideoDb> GetByIdAsync(string id);
        void Create(ResultVideoDb video);
        void Update(ResultVideoDb video);
        void Delete(string id);
        void Save();
        Task SaveChangeAsync();
    }
}