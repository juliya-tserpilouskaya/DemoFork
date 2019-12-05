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
        SearchRequestDb SaveRequest(SearchRequestDb request);

        SearchRequestDb EditRequest(SearchRequestDb request);

        SearchRequestDb DeleteRequest(string requestId);

        IEnumerable<SearchRequestDb> GetAllRequests();

        SearchRequestDb GetRequestById(string requestId);
    }
}
