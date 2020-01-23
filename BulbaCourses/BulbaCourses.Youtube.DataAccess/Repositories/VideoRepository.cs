using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private YoutubeContext _db;
        private bool _isDisposed = false;

        public VideoRepository(YoutubeContext youtubeContext)
        {
            _db = youtubeContext;
        }
        //GetById
        public ResultVideoDb GetById(string id)
        {
            return _db.Videos.Include(_ => _.Channel).SingleOrDefault(x => x.Id == id);
        }

        public async Task<ResultVideoDb> GetByIdAsync(string id)
        {
            return await _db.Videos.SingleOrDefaultAsync(x => x.Id == id);
        }

        //GetAll
        public IEnumerable<ResultVideoDb> GetAll()
        {
            return _db.Videos.ToList().AsReadOnly();
        }

        public async Task<IEnumerable<ResultVideoDb>> GetAllAsync()
        {
            return await _db.Videos.ToListAsync();
        }


        //Save
        public ResultVideoDb Save(ResultVideoDb video)
        {
            _db.Videos.Add(video);
            _db.SaveChanges();
            return video;
        }

        public Task<ResultVideoDb> SaveChangeAsync(ResultVideoDb video)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}