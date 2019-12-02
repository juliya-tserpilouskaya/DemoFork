using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.DataAccess.Repositories
{
    public class RequestsRepository : IRequestsRepository
    {
        private YoutubeContext context;

        public RequestsRepository(YoutubeContext ctx)
        {
            context = ctx;
        }

        public IQueryable<SearchRequest> SearchRequests => context.SearchRequests;

        public SearchRequest SaveRequest(SearchRequest request)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                context.SearchRequests.Add(request);
            }
            else
            {
                var editRequest = context.SearchRequests.SingleOrDefault(r => r.Id == request.Id);
                if (editRequest != null)
                {
                    editRequest.Title = request.Title;
                    editRequest.Description = request.Description;
                }                
            }

            context.SaveChanges();
            return request;
        }

        public SearchRequest DeleteRequest(string requestId)
        {
            var delRequest = context.SearchRequests.SingleOrDefault(r => r.Id == requestId);
            if (delRequest != null)
            {
                context.SearchRequests.Remove(delRequest);
                context.SaveChanges();
            }

            return delRequest;
        }

        public IEnumerable<SearchRequest> GetAllRequests()
        {
            return context.SearchRequests.ToList().AsReadOnly();
        }

        public SearchRequest GetRequestById(string requestId)
        {
            return context.SearchRequests.SingleOrDefault(r => r.Id == requestId);
        }
    }
}