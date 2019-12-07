using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class SearchResultList
    {
        private List<SearchResult> _results = new List<SearchResult>();
        internal void Add(SearchResult result)
        {
            _results.Add(result);
        }
        internal int Length()
        {
            return _results.Count();
        }
    }
}
