using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models
{
    public class SearchQueryStorage
    {
        public static List<SearchQuery> _queries = new List<SearchQuery>()
        {
            new SearchQuery
            {
                Id = Guid.NewGuid().ToString(),
                Query = "basics c",
                Date = DateTime.Now,
            },
            new SearchQuery
            {
                Id = Guid.NewGuid().ToString(),
                Query = "c# advanced",
                Date = DateTime.Now,
            },
            new SearchQuery
            {
                Id = Guid.NewGuid().ToString(),
                Query = "php 9 podcast",
                Date = DateTime.Now,
            }
        };

        public static IEnumerable<SearchQuery> GetAll()
        {
            return _queries.AsReadOnly();
        }

        public static SearchQuery Add(SearchQuery query)
        {
            query.Id = Guid.NewGuid().ToString();
            _queries.Add(query);
            return query;
        }

        public static void RemoveById(string id)
        {
            var query = _queries.SingleOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _queries.Remove(query);
        }

        public static void RemoveAll()
        {
            _queries.Clear();
        }

    }
}