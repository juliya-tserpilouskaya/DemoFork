using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Logic.Models;

namespace BulbaCourses.GlobalSearch.Logic.InterfaceServices
{
    public interface ISearchQueryService
    {
        IEnumerable<SearchQueryDB> GetAll();
        SearchQueryDB GetById(string id);
        SearchQueryDB Add(SearchQueryDB query);
        void RemoveById(string id);
        void RemoveAll();
    }
}
