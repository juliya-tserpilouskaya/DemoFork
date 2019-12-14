using System;

namespace BulbaCourses.Analytics.BLL.Services
{
    public partial class ReportService
    {
        private bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            _context.Dispose();
            _isDisposed = true;

            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        ~ReportService()
        {
            Dispose(false);
        }
    }
}
