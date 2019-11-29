using BulbaCourses.Youtube.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Controllers
{
    public class VideoRepository : IRepository
    {
        private VideoContext _db;
        private bool _isDisposed = false;

        public VideoRepository()
        {
            _db = new VideoContext();
        }
        public Video GetById(int? id)
        {
            return _db.Videos.Find(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _db.Videos.ToList().AsReadOnly();
        }

        
        public void Create(Video videoEntity)
        {
            _db.Videos.Add(videoEntity);
        }

        public void Update(Video videoEntity)
        {
            _db.Entry(videoEntity).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            var video = _db.Videos.Find(id);
            if (video != null)
                _db.Videos.Remove(video);
        }

        public void Save()
        {
            _db.SaveChanges();
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