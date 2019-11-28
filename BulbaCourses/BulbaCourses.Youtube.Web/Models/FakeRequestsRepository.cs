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
            new SearchRequest() { Id =  1, Title = "request1", VideoId = "1", UserId = "1", Url = "url1", Author = "author1", Description = "description1", Channel = "1", PlayList = "1", PublishedAt = DateTime.Now},
            new SearchRequest() { Id =  2, Title = "request2", VideoId = "2", UserId = "2", Url = "url2", Author = "author1", Description = "description2", Channel = "2", PlayList = "2", PublishedAt = DateTime.Now}
        };

        public void SaveRequest(SearchRequest request)
        {
            if (request.Id == 0)
            {
                SearchRequests.Add(request);
            }
            else
            {
                var editRequest = SearchRequests.FirstOrDefault(r => r.Id == request.Id);
                if (editRequest != null)
                {
                    editRequest.Title = request.Title;
                    editRequest.Description = request.Description;
                }                
            }
        }

        public SearchRequest DeleteRequest(int requestId)
        {
            var delRequest = SearchRequests.FirstOrDefault(r => r.Id == requestId);
            if (delRequest != null)
            {
                SearchRequests.Remove(delRequest);
            }

            return delRequest;
        }

        public SearchRequest GetRequestById(int requestId)
        {
            return SearchRequests.SingleOrDefault(r => r.Id == requestId);
        }
    }
}