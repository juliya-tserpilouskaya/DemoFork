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

        /// <summary>
        /// Get all queries from the storage
        /// </summary>
        /// <returns>A collection of Search Queries</returns>
        public static IEnumerable<SearchQuery> GetAll()
        {
            return _queries.AsReadOnly();
        }
        /// <summary>
        /// Get all search queries from the storage
        /// </summary>
        /// <param name="id">Guid of query</param>
        /// <returns>SearchQuery</returns>
        public static SearchQuery GetById(string id)
        {
            return _queries.SingleOrDefault(q => q.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// Add query to the storage
        /// </summary>
        /// <param name="query">Query to add</param>
        /// <returns>Added query</returns>
        public static SearchQuery Add(SearchQuery query)
        {
            query.Id = Guid.NewGuid().ToString();
            _queries.Add(query);
            return query;
        }
        /// <summary>
        /// Remove storage from the storage by id
        /// </summary>
        /// <param name="id">Guid of query</param>
        public static void RemoveById(string id)
        {
            var query = _queries.SingleOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            _queries.Remove(query);
        }
        /// <summary>
        /// Remove all queries from storage
        /// </summary>
        public static void RemoveAll()
        {
            _queries.Clear();
        }

    }
}