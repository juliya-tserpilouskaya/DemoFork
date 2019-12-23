using BulbaCourses.Video.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Video.Data.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly VideoDbContext _videoDbContext;
        private bool _isDisposed = false;

        protected BaseRepository(VideoDbContext videoDbContext)
        {
            _videoDbContext = videoDbContext;
        }

        public void Dispose()
        {
            this.Dispose(true);

        }

        protected void Dispose(bool flag)
        {
            if (_isDisposed) return;

            _videoDbContext?.Dispose();
            _isDisposed = true;
            if (flag) GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            this.Dispose(false);
        }
    }
}
