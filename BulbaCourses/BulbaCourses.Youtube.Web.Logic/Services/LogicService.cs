using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using AutoMapper;
using static Google.Apis.YouTube.v3.SearchResource.ListRequest;

namespace BulbaCourses.Youtube.Web.Logic.Services
{
    public class LogicService : ILogicService
    {
        IServiceFactory _serviceFactory;
        Mapper _mapperSearchRequest;
        Mapper _mapperUser;

        public LogicService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _mapperSearchRequest = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<SearchRequest, SearchRequestDb>()));
            _mapperUser = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<User, UserDb>()));
        }

        public IEnumerable<ResultVideoDb> SearchRun(SearchRequest searchRequest, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultVideoDb>> SearchRunAsync(SearchRequest searchRequest, User user)
        {
            var _cache = _serviceFactory.CreateCacheService();
            var _requestService = _serviceFactory.CreateSearchRequestService();
            var _userService = _serviceFactory.CreateUserService();
            var _storyService = _serviceFactory.CreateStoryService();
            var resultVideos = new List<ResultVideoDb>();
            
            //Mapping models
            var searchRequestDb = _mapperSearchRequest.Map<SearchRequestDb>(searchRequest);
            var userDb = _mapperUser.Map<UserDb>(user);


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
                resultVideos = await SearchInYoutubeAsync(searchRequest);

                searchRequestDb.Videos = resultVideos;

                //add result to cache
                _cache.Add(searchRequestDb);
            }

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

        private async Task<List<ResultVideoDb>> SearchInYoutubeAsync(SearchRequest searchRequest)
        {
            // Create the service.
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAZQwG0x87WljOsVjJGfL1fIC30EWf42pg",
                ApplicationName = "BulbaCourses"
            });

            // Run the request.

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Type = "video";
            searchListRequest.PublishedAfter = searchRequest.PublishedAfter;
            searchListRequest.PublishedBefore = searchRequest.PublishedBefore;
            searchListRequest.VideoDefinition = (VideoDefinitionEnum)Enum.Parse(typeof(VideoDefinitionEnum), searchRequest.Definition);
            searchListRequest.VideoDimension = (VideoDimensionEnum)Enum.Parse(typeof(VideoDimensionEnum), searchRequest.Dimension);
            searchListRequest.VideoDuration = (VideoDurationEnum)Enum.Parse(typeof(VideoDurationEnum), searchRequest.Duration);
            searchListRequest.VideoCaption = (VideoCaptionEnum)Enum.Parse(typeof(VideoCaptionEnum), searchRequest.VideoCaption);
            searchListRequest.Q = searchRequest.Title;
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified searchRequest
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<ResultVideoDb> resultVideos = new List<ResultVideoDb>();
            var _channelService = _serviceFactory.CreateChannelService();

            foreach (var searchResult in searchListResponse.Items)
            {
                var searchListVideo = youtubeService.Videos.List("contentDetails");
                searchListVideo.Id = searchResult.Id.VideoId;
                var responceVideo = await searchListVideo.ExecuteAsync();
                var videoContentDetails = responceVideo.Items[0].ContentDetails;

                ResultVideoDb resultVideo = new ResultVideoDb();
                resultVideo.Id = searchResult.Id.VideoId;
                resultVideo.Title = searchResult.Snippet.Title;
                resultVideo.PublishedAt = searchResult.Snippet.PublishedAt;
                resultVideo.Description = searchResult.Snippet.Description;
                resultVideo.Thumbnail = searchResult.Snippet.Thumbnails.High.Url;
                resultVideo.Definition = videoContentDetails.Definition;
                resultVideo.Dimension = videoContentDetails.Dimension;
                resultVideo.Duration = videoContentDetails.Duration;
                resultVideo.VideoCaption = videoContentDetails.Caption;

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
