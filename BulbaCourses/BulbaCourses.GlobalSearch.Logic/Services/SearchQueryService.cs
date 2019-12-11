using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.GlobalSearch.Logic.Services
{
    public class SearchQueryService : ISearchQueryService
    {

        public IEnumerable<SearchQuery> GetAll()
        {
            return SearchQueryStorage.GetAll();
        }

        public SearchQuery GetById(string id)
        {
            return SearchQueryStorage.GetById(id);
        }

        public SearchQuery Add(SearchQuery query)
        {
            return SearchQueryStorage.Add(query);
        }

        public void RemoveById(string id)
        {
            SearchQueryStorage.RemoveById(id);
        }

        public void RemoveAll()
        {
            SearchQueryStorage.RemoveAll();
        }
    }
}
