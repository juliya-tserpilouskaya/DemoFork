using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class SearchResultList
    {
        private List<CourseInfo> _results = new List<CourseInfo>();
        internal void Add(CourseInfo result)
        {
            _results.Add(result);
        }
        internal int Length()
        {
            return _results.Count();
        }
    }
}
