using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Logic.Services;
using BulbaCourses.Youtube.Web.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Linq;
using BulbaCourses.Youtube.Logic.Models;
using Ninject;
using BulbaCourses.Youtube.Logic;
using BulbaCourses.Youtube.DataAccess.Repositories;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.DataAccess;

namespace BulbaCourses.Youtube.Tests
{
    [TestFixture]
    class StoryControllerTest
    {
        Faker<SearchRequest> fakerRequest;
        Faker<SearchStory> fakerStory;
        IStoryService stService;
        StoryController stController;
        StandardKernel kernel;
        List<SearchRequest> searchRequest = new List<SearchRequest>();
        string user1 = "user1";

        [OneTimeSetUp]
        public void Init()
        {
            var definition = new[] { "High", "Standard", "Any" };
            var dimension = new[] { "Value2d", "Value3d", "Any" };
            var duration = new[] { "Long__", "Medium", "Short__", "Any" };
            var caption = new[] { "ClosedCaption", "None", "Any" };
            fakerRequest = new Faker<SearchRequest>()
                .RuleFor(r => r.Title, f => f.Random.Word())
                .RuleFor(r => r.CacheId, f => f.Random.Word())
                .RuleFor(r => r.Definition, f => f.PickRandom(definition))
                .RuleFor(r => r.Dimension, f => f.PickRandom(dimension))
                .RuleFor(r => r.Duration, f => f.PickRandom(duration))
                .RuleFor(r => r.VideoCaption, f => f.PickRandom(caption));

            kernel = new StandardKernel();
            kernel.Load<LogicModule>();
            var requestService = kernel.Get<ISearchRequestService>();

            for (int i = 0; i < 3; i++)
                searchRequest.Add(requestService.Save(fakerRequest.Generate(1).First()));

            fakerStory = new Faker<SearchStory>();
            fakerStory.RuleFor(s => s.SearchDate, f => f.Date.Past(1, null))
                .RuleFor(s => s.SearchRequest_Id, f => f.PickRandom(searchRequest).Id)
                .RuleFor(s => s.UserId, f => user1);

            stService = kernel.Get<IStoryService>();
            stController = new StoryController(stService);
        }

        [Test]
        public void Test_GetStory_ByUserId()
        {
            var countBefore = 0;
            var resultListStory = (OkNegotiatedContentResult<IEnumerable<SearchStory>>)stController
                .GetStoryByUserID(user1).GetAwaiter().GetResult();

            countBefore = resultListStory.Content.ToList().Count;

            var storiesDb = fakerStory.Generate(3);
            foreach (var item in storiesDb)
                stService.Save(item);

            resultListStory = (OkNegotiatedContentResult<IEnumerable<SearchStory>>)stController
                .GetStoryByUserID(user1).GetAwaiter().GetResult();

            var result = resultListStory.Content.ToList();

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(c => c == countBefore + 3);

            foreach (var item in result)
                item.UserId.Should().Be(user1);
        }
    }
}
