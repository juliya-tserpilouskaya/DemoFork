using BulbaCourses.Youtube.Web.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public interface IRequestService
    {
        SearchRequest SaveRequest(SearchRequest request);

        SearchRequest EditRequest(SearchRequest request);

        SearchRequest DeleteRequest(string requestId);

        IEnumerable<SearchRequest> GetAllRequests();

        SearchRequest GetRequestById(string requestId);
    }
}
