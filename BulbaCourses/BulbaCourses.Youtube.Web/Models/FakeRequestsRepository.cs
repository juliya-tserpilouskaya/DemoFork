using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Youtube.Web.Models
{
    public class FakeRequestsRepository : IRequestsRepository
    {
        public List<SearchRequest> SearchRequests => new List<SearchRequest>
        {
            new SearchRequest() { Id =  "1", Title = "request1", VideoId = "1", UserId = "1", Url = "url1", Author = "author1", Description = "description1", Channel = "1", PlayList = "1", PublishedAt = DateTime.Now},
            new SearchRequest() { Id =  "2", Title = "request2", VideoId = "2", UserId = "2", Url = "url2", Author = "author1", Description = "description2", Channel = "2", PlayList = "2", PublishedAt = DateTime.Now}
        };

        public SearchRequest SaveRequest(SearchRequest request)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                SearchRequests.Add(request);
            }
            else
            {
                var editRequest = SearchRequests.SingleOrDefault(r => r.Id == request.Id);
                if (editRequest != null)
                {
                    editRequest.Title = request.Title;
                    editRequest.Description = request.Description;
                }                
            }

            return request;
        }

        public SearchRequest DeleteRequest(string requestId)
        {
            var delRequest = SearchRequests.SingleOrDefault(r => r.Id == requestId);
            if (delRequest != null)
            {
                SearchRequests.Remove(delRequest);
            }

            return delRequest;
        }

        public IEnumerable<SearchRequest> GetAllRequests()
        {
            return SearchRequests.AsReadOnly();
        }

        public SearchRequest GetRequestById(string requestId)
        {
            return SearchRequests.SingleOrDefault(r => r.Id == requestId);
        }
    }
}