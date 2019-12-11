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

        ICacheService _cache;

        public LogicService(IStoryService storyService, 
            IVideoService videoService, ISearchRequestService requestService, ICacheService cache)
        {
            _storyService = storyService;
            _videoService = videoService;
            _requestService = requestService;
            _cache = cache;
        }
        public IEnumerable<ResultVideoDb> SearchRun(SearchRequest searchRequest)
        {
            //convert searchRequest to searchRequestDb
            SearchRequestDb searchRequestDb = new SearchRequestDb();
            searchRequestDb.Title = searchRequest.Title;

            var resultVideos = new List<ResultVideoDb>();
            var cacheResult = _cache.GetValue(searchRequestDb.Id);

            if (!_requestService.Exists(searchRequestDb))
            {
                //save search request
                searchRequestDb = _requestService.Save(searchRequestDb);
            }

            if (cacheResult != null)
            {
                //get videos list from cache
                resultVideos = cacheResult.Videos.ToList();

                //update cache for search request for refresh storage time in the cache
                _cache.Update(searchRequestDb);
            }
            else
            {                
                //Search in Youtube service
                resultVideos = SearchInYoutube(searchRequest);

                searchRequestDb.Videos = resultVideos;

                //add result to cache
                _cache.Add(searchRequestDb);
            }             

            //add search user story
            _storyService.Save(new SearchStoryDb()
            {
                SearchDate = DateTime.Now,
                SearchRequest = searchRequestDb,
                User = new UserDb()
            });           

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
                //здесь, наверное, нужно сохранять информацию о каждом видео в базу, так как у нас есть соответствующая таблица Video в базе
            }
            return resultVideos;
        }
    }
}
