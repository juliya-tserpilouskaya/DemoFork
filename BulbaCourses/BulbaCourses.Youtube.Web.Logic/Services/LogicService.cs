using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class LogicService : ILogicService
    {
        IStoryService _storyService;
        IVideoService _videoService;
        ISearchRequestService _requestService;
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
            SearchRequestDb searchRequestDb = new SearchRequestDb();
            searchRequestDb.Title = searchRequest.Title;

            if (!_requestService.Exists(searchRequestDb))
                searchRequestDb = _requestService.Save(searchRequestDb);
            _storyService.Save(new SearchStoryDb()
            {
                SearchDate = DateTime.Now,
                SearchRequest = searchRequestDb,
                User = new UserDb()
            });

            //Search in Youtube service
            List<ResultVideoDb> resultVideos = SearchInYoutube(searchRequest);


            return resultVideos.AsReadOnly();
        }

        private List<ResultVideoDb> SearchInYoutube(SearchRequest searchRequest)
        {
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

            List<ResultVideoDb> resultVideos = new List<ResultVideoDb>();
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
                resultVideos.Add(resultVideo);
            }
            return resultVideos;
        }
    }
}
