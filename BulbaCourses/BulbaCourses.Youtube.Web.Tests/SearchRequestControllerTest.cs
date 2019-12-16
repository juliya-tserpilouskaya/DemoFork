using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Web.Logic.Services;
using BulbaCourses.Youtube.Web.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using BulbaCourses.Youtube.Web.DataAccess;
using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    class SearchRequestControllerTest
    {
        SearchRequestController srController;
        SearchRequestsRepository srRepo;
        StoryRepository sRepo;
        VideoRepository vRepo;

        [OneTimeSetUp]
        public void Init()
        {
            var youtubeContext = new YoutubeContext();
            var srRepo = new SearchRequestsRepository(youtubeContext);
            var sRepo = new StoryRepository(youtubeContext);
            var vRepo = new VideoRepository(youtubeContext);
            var uRepo = new UserRepository(youtubeContext);
            var cRepo = new ChannelRepository(youtubeContext);

            var srService = new SearchRequestService(srRepo);
            var sService = new StoryService(sRepo);
            var vService = new VideoService(vRepo);

            var cService = new ChannelService(cRepo);
            var uService = new UserService(uRepo);
            var cache = new CacheService();

            var lService = new LogicService(sService, vService, srService, cache, uService, cService);

            srController = new SearchRequestController(lService);
        }

        [Test]
        public void Test_SearchVideo()
        {
            var searchRequest = new SearchRequest();
            searchRequest.Title = "2015 05 03 Открытое занятие";

            var resultListVideo =
                (OkNegotiatedContentResult<IEnumerable<ResultVideoDb>>)srController.SearchRun(searchRequest)
                .GetAwaiter().GetResult();

            var result = resultListVideo.Content.ToList();

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(c => c > 3);
            result.First().Title.Should().Be("2015 05 03  Открытое занятие 8");
        }
    }
}
