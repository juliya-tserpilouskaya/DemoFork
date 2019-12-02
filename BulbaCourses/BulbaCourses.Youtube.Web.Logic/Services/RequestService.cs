using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class RequestService : IRequestService
    {
        IRequestsRepository _requestRepository;
        public RequestService(IRequestsRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public SearchRequest SaveRequest(SearchRequest request)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                var result = _requestRepository.SaveRequest(request);
                return result;
            }
            else
            {
                return null;
            }
        }

        public SearchRequest EditRequest(SearchRequest request)
        {
            var editRequest = _requestRepository.GetRequestById(request.Id);

            if (!string.IsNullOrEmpty(request.Id))
            {               
                if (editRequest != null)
                {
                    editRequest = _requestRepository.SaveRequest(request);
                }
            }

            return editRequest;
        }

        public SearchRequest DeleteRequest(string requestId)
        {
            var delRequest = _requestRepository.GetRequestById(requestId);
            if (delRequest != null)
            {
                _requestRepository.DeleteRequest(delRequest.Id);
            }

            return delRequest;
        }

        public IEnumerable<SearchRequest> GetAllRequests()
        {
            return _requestRepository.GetAllRequests();
        }

        public SearchRequest GetRequestById(string requestId)
        {
            if (!string.IsNullOrEmpty(requestId))
                return _requestRepository.GetRequestById(requestId);
            return null;
        }
    }
}
