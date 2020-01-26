using System;
using Swashbuckle.Examples;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Models.SwaggerExamples.SearchRequests
{
    /// <summary>
    /// Represents a example of model view search request.
    /// </summary>
    public class SearchRequestExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view search request.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new SearchRequest()
            {
                Title = "create angular app"
            };

            return value;
        }
    }
}
