using BulbaCourses.Podcasts.Logic.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Tests")]

namespace BulbaCourses.Podcasts.Logic.Services
{
    public enum SearchMode { ByTitle, ByAuthor, ByTheme }
    class SearchService : ISearchService
    {
        public static int SearchCount = 20;
        public SearchResultList GetSearchResults(string searchString, SearchMode type)
        {
            try
            {
                SearchResultList result = CourseStorage.Search(searchString, type);
                return result;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
