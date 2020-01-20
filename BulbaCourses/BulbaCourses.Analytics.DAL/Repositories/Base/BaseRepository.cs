using BulbaCourses.Analytics.DAL.Context;
using System;

namespace BulbaCourses.Analytics.DAL.Repositories.Base
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly AnalyticsContext _context;
        private bool _isDisposed = false;

        protected BaseRepository()
        {
            _context = new AnalyticsContext();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;

            _context?.Dispose();
            _isDisposed = true;

            if (flag) GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            Dispose(false);
        }
    }
}
