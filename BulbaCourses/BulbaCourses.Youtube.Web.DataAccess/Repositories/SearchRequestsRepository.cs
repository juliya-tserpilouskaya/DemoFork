using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public class SearchRequestsRepository : ISearchRequestsRepository
    {
        private YoutubeContext _context;
        private bool _isDisposed = false;

        public SearchRequestsRepository(YoutubeContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<SearchRequestDb> SearchRequests => _context.SearchRequests;

        public SearchRequestDb SaveRequest(SearchRequestDb request)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                 _context.SearchRequests.Add(request);
            }
            else
            {
                var editRequest = _context.SearchRequests.SingleOrDefault(r => r.Id == request.Id);
                if (editRequest != null)
                {
                    editRequest.Title = request.Title;
                    //editRequest.Description = request.Description;
                }                
            }
            _context.SaveChanges();
            return request;
        }

        public SearchRequestDb DeleteRequest(string requestId)
        {
            var delRequest = _context.SearchRequests.SingleOrDefault(r => r.Id == requestId);
            if (delRequest != null)
            {
                _context.SearchRequests.Remove(delRequest);
                _context.SaveChanges();
            }
            return delRequest;
        }

        public IEnumerable<SearchRequestDb> GetAllRequests()
        {
            return _context.SearchRequests.ToList().AsReadOnly();
        }

        public SearchRequestDb GetRequestById(string requestId)
        {
            return _context.SearchRequests.SingleOrDefault(r => r.Id == requestId);
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