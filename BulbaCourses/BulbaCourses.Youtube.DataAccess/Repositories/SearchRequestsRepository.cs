using BulbaCourses.Youtube.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BulbaCourses.Youtube.DataAccess.Repositories
{
    public class SearchRequestsRepository : ISearchRequestsRepository
    {
        private YoutubeContext _context;
        private bool _isDisposed = false;

        public SearchRequestsRepository(YoutubeContext ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Save Changes Async
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public SearchRequestDb SaveRequest(SearchRequestDb request)
        {
            var videosFromDb = new List<ResultVideoDb>();
            foreach (var video in request.Videos)
            {
                videosFromDb.Add(_context.Videos.Find(video.Id));
            }
            request.Videos = videosFromDb;
            _context.SearchRequests.Add(request);
            _context.SaveChanges();
            return request;
        }

        public SearchRequestDb Update(SearchRequestDb request)
        {
            var requestFromDb = _context.SearchRequests.Find(request.Id);
            var videosFromDb = new List<ResultVideoDb>();
            foreach (var video in request.Videos)
            {
                videosFromDb.Add(_context.Videos.Find(video.Id));
            }
            requestFromDb.Videos = videosFromDb;
            _context.Entry(requestFromDb).State = EntityState.Modified;
            _context.SaveChanges();
            return requestFromDb;
        }


        public void DeleteRequest(int? requestId)
        {
            var delRequest = _context.SearchRequests.SingleOrDefault(r => r.Id == requestId);
            if (delRequest != null)
            {
                _context.SearchRequests.Remove(delRequest);
                _context.SaveChanges();
            }
        }

        public bool Exists(SearchRequestDb searchRequest)
        {
            return _context.SearchRequests.Any(r => r.CacheId == searchRequest.CacheId);
        }

        public IEnumerable<SearchRequestDb> GetAllRequests()
        {
            return _context.SearchRequests.ToList().AsReadOnly();
        }

         public SearchRequestDb GetRequestByCacheId(string cacheId)
        {
            return _context.SearchRequests.SingleOrDefault(r => string.Equals(r.CacheId, cacheId));
        }

        //Async methods
        public async Task<IEnumerable<SearchRequestDb>> GetAllRequestsAsync()
        {
            return await _context.SearchRequests.ToListAsync();
        }

        public async Task<SearchRequestDb> GetRequestByCacheIdAsync(string cacheId)
        {
            return await _context.SearchRequests.Include(_=>_.Videos).SingleOrDefaultAsync(r => r.CacheId == cacheId);
        }

        //interface method implementation
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;
            _context.Dispose();
            _isDisposed = true;

            if (flag)
                GC.SuppressFinalize(this);
        }

    }
}