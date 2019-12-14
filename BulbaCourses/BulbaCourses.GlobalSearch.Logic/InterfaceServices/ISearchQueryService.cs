using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Logic.Models;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ISearchQueryService
    {
        IEnumerable<SearchQuery> GetAll();
        SearchQuery GetById(string id);
        SearchQuery Add(SearchQuery query);
        void RemoveById(string id);
        void RemoveAll();
    }
}
