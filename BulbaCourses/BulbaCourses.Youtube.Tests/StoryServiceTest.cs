using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.DataAccess;
using BulbaCourses.Youtube.DataAccess.Repositories;
using BulbaCourses.Youtube.DataAccess.Models;
using BulbaCourses.Youtube.Logic.Services;
using BulbaCourses.Youtube.Logic.Models;
using BulbaCourses.Youtube.Logic;
using Ninject;

namespace BulbaCourses.Youtube.Tests
{
    [TestFixture]
    class StoryServiceTest
    {
        Faker<SearchRequest> fakerRequest;
        Faker<SearchStory> fakerStory;
        StandardKernel kernel;

        [OneTimeSetUp]
        public void Init()
        {
            kernel = new StandardKernel();
            kernel.Load<LogicModule>();

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


            fakerStory = new Faker<SearchStory>();
            fakerStory.RuleFor(s => s.SearchRequest, f => fakerRequest.Generate(1).First())
                .RuleFor(s => s.SearchDate, f => f.Date.Past(1, null))
                .RuleFor(s => s.UserId, f => f.Random.String());
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_Save()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                var storyDb = fakerStory.Generate(1).First();
                var userId = storyDb.UserId;
                var requestTitle = storyDb.SearchRequest.Title;

                storyService.Save(storyDb);

                var result = context.SearchStories.Where(r => r.UserId == userId).First();
                result.Should().NotBeNull();
            }
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_DeleteByUserId()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                var storyDb = fakerStory.Generate(1).First();

                storyService.Save(storyDb);
                var userId = storyDb.UserId;

                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());

                var result = context.SearchStories.FirstOrDefault(r => r.UserId == userId);
                result.Should().NotBeNull();

                storyService.DeleteByUserId(userId);
                result = context.SearchStories.FirstOrDefault(r => r.UserId == userId);
                result.Should().BeNull();
            }
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_DeleteByStoryId()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                var storyDb = fakerStory.Generate(1).First();
                storyDb = storyService.Save(storyDb);
                var storyId = storyDb.Id;

                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());

                var result = context.SearchStories.FirstOrDefault(r => r.Id == storyId);
                result.Should().NotBeNull();

                storyService.DeleteByStoryId(storyId);
                result = context.SearchStories.FirstOrDefault(r => r.Id == storyId);
                result.Should().BeNull();
            }
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_GetAllStories()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                var count = context.SearchStories.Count();

                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());

                var allStories = storyService.GetAllStories().ToList();

                allStories.Should().HaveCount(count + 3);
            }
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_GetStoriesByUserId()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());

                var storyDb = fakerStory.Generate(1).First();
                storyService.Save(storyDb);
                var userId = storyDb.UserId;

                var story = storyService.GetStoriesByUserId(userId).First();

                story.UserId.Should().Be(userId);
            }
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_GetStoriesByRequestId()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());

                var storyDb = fakerStory.Generate(1).First();
                storyDb = storyService.Save(storyDb);
                var requestId = storyDb.SearchRequest.Id;

                var story = storyService.GetStoriesByRequestId(requestId).First();

                story.SearchRequest.Id.Should().Be(requestId);
            }
        }

        [Test, Category("SearchStory")]
        public void Test_SearchStory_GetStoriesByStoryId()
        {
            using (var context = new YoutubeContext())
            {
                var storyService = kernel.Get<IStoryService>();

                storyService.Save(fakerStory.Generate(1).First());
                storyService.Save(fakerStory.Generate(1).First());

                var storyDb = fakerStory.Generate(1).First();
                storyDb = storyService.Save(storyDb);
                var storyId = storyDb.Id;

                var story = storyService.GetStoryByStoryId(storyId);

                story.Id.Should().Be(storyId);
            }
        }
    }
}
