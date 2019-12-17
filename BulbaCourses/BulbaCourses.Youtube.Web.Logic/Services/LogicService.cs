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
        ICacheService _cache;
        Mapper _mapper;

        public LogicService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _cache = _serviceFactory.CreateCacheService();
            _mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.CreateMap<SearchRequest, SearchRequestDb>();
                cfg.CreateMap<User, UserDb>();
                cfg.CreateMap<List<ResultVideoDb>, List<ResultVideo>>();
            }));             
        }

        public IEnumerable<ResultVideo> SearchRun(SearchRequest searchRequest, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultVideo>> SearchRunAsync(SearchRequest searchRequest, User user)
        {
            var _requestService = _serviceFactory.CreateSearchRequestService();
            var _userService = _serviceFactory.CreateUserService();
            var _storyService = _serviceFactory.CreateStoryService();
            var resultVideos = new List<ResultVideoDb>();
            
            //Mapping models
            var searchRequestDb = _mapper.Map<SearchRequestDb>(searchRequest);
            searchRequestDb.CacheId = GenerateCacheId(searchRequestDb);
            var userDb = _mapper.Map<UserDb>(user);

            //Сheck cache
            var cacheResult = _cache.GetValue(searchRequestDb.CacheId);
            if (cacheResult != null)
            {
                //Get videos list from cache
                resultVideos = cacheResult;

                //Update cache for search request for refresh storage time in the cache
                _cache.Update(searchRequestDb.CacheId, resultVideos);
            }
            else
            {
                //Search in Youtube service
                resultVideos = await SearchInYoutubeAsync(searchRequestDb);

                //Add result to cache
                var res = _cache.Add(searchRequestDb.CacheId, resultVideos);
            }
            
            //Save search request if does not exist
            if (!_requestService.Exists(searchRequestDb))
            {
                searchRequestDb.Videos = resultVideos;
                searchRequestDb = _requestService.Save(searchRequestDb);
            }
            //Save user if does not exist
            if(!_userService.Exists(userDb))
                _userService.Save(userDb);

            //Save user search story
            _storyService.Save(new SearchStoryDb()
            {
                SearchDate = DateTime.Now,
                SearchRequest = searchRequestDb,
                User = userDb
            });

            return _mapper.Map<List<ResultVideo>>(resultVideos).AsReadOnly();
        }

        private async Task<List<ResultVideoDb>> SearchInYoutubeAsync(SearchRequestDb searchRequest)
        {
            var _channelService = _serviceFactory.CreateChannelService();
            var resultVideos = new List<ResultVideoDb>();

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
            foreach (var searchResult in searchListResponse.Items)
            {
                var searchListVideo = youtubeService.Videos.List("contentDetails");
                searchListVideo.Id = searchResult.Id.VideoId;
                var responceVideo = await searchListVideo.ExecuteAsync();
                var videoContentDetails = responceVideo.Items[0].ContentDetails;

                var resultVideo = new ResultVideoDb();
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
        private string GenerateCacheId(SearchRequestDb searchRequestDb)
        {
            var cacheId = searchRequestDb.PublishedAfter.ToString()
                + searchRequestDb.PublishedBefore.ToString()
                + searchRequestDb.Definition
                + searchRequestDb.Dimension
                + searchRequestDb.Duration
                + searchRequestDb.VideoCaption
                + searchRequestDb.Title;
            return cacheId;
        }
    }
}
