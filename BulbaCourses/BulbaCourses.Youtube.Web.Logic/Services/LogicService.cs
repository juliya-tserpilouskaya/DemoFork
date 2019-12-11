using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Runtime.Caching;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    class LogicService : ILogicService
    {
        IStoryService _storyService;
        IVideoService _videoService;
        ISearchRequestService _requestService;

        private CacheService _cache = new CacheService();

        public LogicService(IStoryService storyService, 
            IVideoService videoService, ISearchRequestService requestService)
        {
            _storyService = storyService;
            _videoService = videoService;
            _requestService = requestService;
        }
        public IEnumerable<ResultVideoDb> SearchRun(SearchRequest searchRequest)
        {
            //convert searchRequest to searchRequestDb
            SearchRequestDb searchRequestDb = new SearchRequestDb()
            {
                Title = searchRequest.Title,
                VideoId = searchRequest.VideoId,
                Author = searchRequest.Author
            };

            List<ResultVideoDb> resultVideos = new List<ResultVideoDb>();
            
            
            //save request if dont exists in the db and get query to youtube
            if (!_requestService.Exists(searchRequestDb))
            {
                _requestService.Save(searchRequestDb);

                // Create the service.
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyAZQwG0x87WljOsVjJGfL1fIC30EWf42pg",
                    ApplicationName = "BulbaCourses"
                });

                // Run the request.
                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = searchRequest.Title;
                searchListRequest.MaxResults = 10;

                // Call the search.list method to retrieve results matching the specified searchRequest
                var searchListResponse = searchListRequest.Execute();

                foreach (var searchResult in searchListResponse.Items)
                {
                    ResultVideoDb resultVideo = new ResultVideoDb();
                    resultVideo.Id = searchResult.Id.VideoId;
                    resultVideo.Etag = searchResult.ETag;
                    resultVideo.Title = searchResult.Snippet.Title;
                    resultVideo.Channel = new ChannelDb()
                    {
                        Id = searchResult.Snippet.ChannelId,
                        Name = searchResult.Snippet.ChannelTitle,
                        Mentor = new MentorDb(),
                        Videos = new List<ResultVideoDb>()
                    };
                    resultVideo.PublishedAt = searchResult.Snippet.PublishedAt;
                    resultVideo.Description = searchResult.Snippet.Description;
                    resultVideo.SearchRequests = new List<SearchRequestDb>();
                    // resultVideo.SearchRequests.Add(searchRequestDb.Id);       //write searchRequestId... !!!

                    resultVideos.Add(resultVideo);
                }
            }                
            else if (_cache.GetValue(searchRequest.Id) != null)
            {
                

            }

            


            return resultVideos.AsReadOnly();
        }
    }
}
