using BulbaCourses.Podcasts.Logic.Models;

namespace BulbaCourses.Podcasts.Logic.Services
{
    public interface ISearchService
    {
        SearchResultList GetSearchResults(string searchString, SearchMode type, ref SearchResultList resultList);
    }
}