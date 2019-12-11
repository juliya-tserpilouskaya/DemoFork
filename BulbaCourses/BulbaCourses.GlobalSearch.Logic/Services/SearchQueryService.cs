using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services.Interfaces;
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
        ISearchQueryDbService _searchQueryDb;

        public SearchQueryService(ISearchQueryDbService searchQueryDb)
        {
            _searchQueryDb = searchQueryDb;
        }
        public IEnumerable<SearchQueryDB> GetAll()
        {
            return _searchQueryDb.GetAll();
        }

        public SearchQueryDB GetById(string id)
        {
            return _searchQueryDb.GetById(id);
        }

        public SearchQueryDB Add(SearchQueryDB query)
        {
            return _searchQueryDb.Add(query);
        }

        public void RemoveById(string id)
        {
            _searchQueryDb.RemoveById(id);
        }

        public void RemoveAll()
        {
            _searchQueryDb.RemoveAll();
        }
    }
}
