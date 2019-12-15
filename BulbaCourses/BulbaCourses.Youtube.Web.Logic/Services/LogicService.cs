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

        IChannelService _channelService;
        IUserService _userService;
        ICacheService _cache;

        public LogicService(IStoryService storyService, 
            IVideoService videoService, ISearchRequestService requestService, 
            ICacheService cache, IUserService userService, IChannelService channelService)
        {
            _storyService = storyService;
            _videoService = videoService;
            _requestService = requestService;
            _cache = cache;
            _userService = userService;
            _channelService = channelService;
        }
        public IEnumerable<ResultVideoDb> SearchRun(SearchRequest searchRequest, User user)
        {
            var resultVideos = new List<ResultVideoDb>();

            //convert searchRequest to searchRequestDb
            var searchRequestDb = ParsеToDAL(searchRequest);

            var cacheResult = _cache.GetValue(searchRequestDb.Id);

            //save search request if does not exist
            if (!_requestService.Exists(searchRequestDb))
                searchRequestDb = _requestService.Save(searchRequestDb);

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

            var userDb = new UserDb()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Login = user.Login,
                Password = user.Password,
                NumberPhone = user.NumberPhone,
                Email = user.Email,
                ReserveEmail = user.ReserveEmail
            };

            _userService.Save(userDb);
            var serachStoryDB = new SearchStoryDb()
            {
                SearchDate = DateTime.Now,
                SearchRequest = searchRequestDb,
                User = userDb
            };
            //add search user story
            _storyService.Save(serachStoryDB);

            return resultVideos.AsReadOnly();
        }

        private SearchRequestDb ParsеToDAL(SearchRequest searchRequest)
        {
            SearchRequestDb searchRequestDb = new SearchRequestDb();
            searchRequestDb.Title = searchRequest.Title;
            searchRequestDb.Id = searchRequest.Id;
            searchRequestDb.VideoId = searchRequest.VideoId;
            searchRequestDb.Author = searchRequest.Author;
            return searchRequestDb;
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
            searchListRequest.MaxResults = 8;

            // Call the search.list method to retrieve results matching the specified searchRequest
            var searchListResponse = searchListRequest.Execute();

            List<ResultVideoDb> resultVideos = new List<ResultVideoDb>();
            foreach (var searchResult in searchListResponse.Items.Where(r=>r.Id.VideoId!=null))
            {
                ResultVideoDb resultVideo = new ResultVideoDb();
                resultVideo.Id = searchResult.Id.VideoId;
                resultVideo.Etag = searchResult.ETag;
                resultVideo.Title = searchResult.Snippet.Title;
                resultVideo.PublishedAt = searchResult.Snippet.PublishedAt;
                resultVideo.Description = searchResult.Snippet.Description;

                var channel = new ChannelDb()
                {
                    Id = searchResult.Snippet.ChannelId,
                    Name = searchResult.Snippet.ChannelTitle,
                };
                if (!_channelService.Exists(channel))
                    _channelService.Save(channel);

                resultVideo.Channel = _channelService.GetChannelById(channel.Id);

                resultVideos.Add(resultVideo);
            }
            return resultVideos;
        }
    }
}
