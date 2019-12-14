using BulbaCourses.Podcasts.Logic.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BulbaCourses.Podcasts.Tests")]

namespace BulbaCourses.Podcasts.Logic.Services
{
    public enum SearchMode { ByTitle, ByAuthor, ByTheme }
    internal class SearchService : ISearchService
    {
        public static int SearchCount = 20;
        public SearchResultList GetSearchResults(string searchString, SearchMode type, ref SearchResultList resultList)
        {
            try
            {
                SearchResultList result = CourseStorage.Search(searchString, type, ref resultList);
                return result;
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
