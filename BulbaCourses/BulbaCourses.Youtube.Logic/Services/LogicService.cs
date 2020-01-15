using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using AutoMapper;
using FluentValidation;
using static Google.Apis.YouTube.v3.SearchResource.ListRequest;

namespace BulbaCourses.Youtube.Logic.Services
{
    public class LogicService : ILogicService
    {
        IServiceFactory _serviceFactory;
        ICacheService _cache;
        readonly IMapper _mapper;
        private readonly IValidator<SearchRequest> _validator;

        public LogicService(IServiceFactory serviceFactory, IMapper mapper, IValidator<SearchRequest> validator)
        {
            _serviceFactory = serviceFactory;
            _cache = _serviceFactory.CreateCacheService();
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<ResultVideo> SearchRun(SearchRequest searchRequest, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultVideo>> SearchRunAsync(SearchRequest searchRequest, string userId)
        {
            var result = _validator.Validate(searchRequest, ruleSet: "AddRequest, Search");
            if (!result.IsValid)
                return null;

            var requestService = _serviceFactory.CreateSearchRequestService();
            var storyService = _serviceFactory.CreateStoryService();
            var videoService = _serviceFactory.CreateVideoService();

            var resultVideos = new List<ResultVideo>();

            searchRequest.CacheId = GenerateCacheId(searchRequest);

            //Сheck cache
            var cacheResult = _cache.GetValue(searchRequest.CacheId);
            if (cacheResult != null)
            {
                //Get videos list from cache
                resultVideos = cacheResult;

                //Update cache for search request for refresh storage time in the cache
                _cache.Update(searchRequest.CacheId, resultVideos);
            }
            else
            {
                //Search in Youtube service
                resultVideos = await SearchInYoutubeAsync(searchRequest);

                //Add result to cache
                _cache.Add(searchRequest.CacheId, resultVideos);
            }

            //Save ResultVideo and SearchRequest if does not exist
            var videoFromDb = new ResultVideo();
            if (requestService.Exists(searchRequest))
            {
                searchRequest = await requestService.GetRequestByCacheIdAsync(searchRequest.CacheId);

                foreach (var resultVideo in resultVideos)
                {
                    if (!searchRequest.Videos.Any(v=>v.Id ==resultVideo.Id))
                        searchRequest.Videos.Add(resultVideo);
                }
                requestService.Update(searchRequest);
            }
            else
            {
                searchRequest.Videos = resultVideos;
                searchRequest = requestService.Save(searchRequest);
            }

            //Save user search story
            storyService.Save(new SearchStory()
            {
                SearchDate = DateTime.Now,
                //SearchRequest = searchRequest,
                SearchRequest_Id = searchRequest.Id,

                UserId = userId
            });
            return resultVideos.AsReadOnly();
        }

        private async Task<List<ResultVideo>> SearchInYoutubeAsync(SearchRequest searchRequest)
        {
            var channelService = _serviceFactory.CreateChannelService();
            var videoService = _serviceFactory.CreateVideoService();

            var resultVideos = new List<ResultVideo>();

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

                var resultVideo = new ResultVideo();
                resultVideo.Id = searchResult.Id.VideoId;
                resultVideo.Title = searchResult.Snippet.Title;
                resultVideo.PublishedAt = searchResult.Snippet.PublishedAt;
                resultVideo.Description = searchResult.Snippet.Description;
                resultVideo.Thumbnail = searchResult.Snippet.Thumbnails.High.Url;
                resultVideo.Definition = videoContentDetails.Definition;
                resultVideo.Dimension = videoContentDetails.Dimension;
                resultVideo.Duration = videoContentDetails.Duration;
                resultVideo.VideoCaption = videoContentDetails.Caption;

                var channel = new Channel()
                {
                    Id = searchResult.Snippet.ChannelId,
                    Name = searchResult.Snippet.ChannelTitle,
                };
                if (!channelService.Exists(channel))
                    channelService.Save(channel);

                resultVideo.Channel_Id = channel.Id;

                var videoFromDb = videoService.GetById(resultVideo.Id);
                if (videoFromDb == null)
                    resultVideo = videoService.Save(resultVideo);
                else
                    resultVideo = videoFromDb;

                resultVideos.Add(resultVideo);
            }
            return resultVideos;
        }
        private string GenerateCacheId(SearchRequest searchRequestDb)
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
