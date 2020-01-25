using System;
using Swashbuckle.Examples;
using BulbaCourses.Youtube.Logic.Models;

namespace BulbaCourses.Youtube.Logic.Models.SwaggerExamples.SearchStories
{
    /// <summary>
    /// Represents a example of model view search story.
    /// </summary>
    public class SearchStoryExample : IExamplesProvider
    {
        /// <summary>
        /// Gets a example of model view search story.
        /// </summary>
        /// <returns></returns>
        public virtual object GetExamples()
        {
            var value = new SearchStory()
            {
                UserId = "guest",
                SearchRequest = new SearchRequest()
                {
                    Title = "Angular"
                }
            };

            return value;
        }
    }
}
