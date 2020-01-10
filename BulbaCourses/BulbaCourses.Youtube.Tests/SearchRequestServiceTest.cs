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

namespace BulbaCourses.Youtube.Tests
{
    [TestFixture]
    class SearchRequestServiceTest
    {
        Faker<SearchRequestDb> fakerRequest;

        [OneTimeSetUp]
        public void Init()
        {
            var definition = new[] { "High","Standard","Any"};
            var dimension = new[] { "Value2d", "Value3d", "Any" };
            var duration = new[] { "Long__", "Medium","Short__", "Any" };
            var caption = new[] { "ClosedCaption", "None", "Any" };

            fakerRequest = new Faker<SearchRequestDb>()
                .RuleFor(r => r.Title, f => f.Random.Word())
                .RuleFor(r => r.CacheId, f => f.Random.Word())
                .RuleFor(r => r.Definition, f => f.PickRandom(definition))
                .RuleFor(r => r.Dimension, f => f.PickRandom(dimension))
                .RuleFor(r => r.Duration, f => f.PickRandom(duration))
                .RuleFor(r => r.VideoCaption, f => f.PickRandom(caption));
        }

        [Test, Category("SearchRequest")]
        public void Test_SearchRequest_Save()
        {
            using (var context = new YoutubeContext())
            {
                var requestRepo = new SearchRequestsRepository(context);
                var requestService = new SearchRequestService(requestRepo);

                var searchRequestDb = fakerRequest.Generate(1).First();
                var title = searchRequestDb.Title;

                requestService.Save(searchRequestDb);

                var result = context.SearchRequests.Where(r => r.Title == title).First();
                result.Should().NotBeNull();
            }
        }

        [Test, Category("SearchRequest")]
        public void Test_SearchRequest_Exists_True()
        {
            using (var context = new YoutubeContext())
            {
                var requestRepo = new SearchRequestsRepository(context);
                var requestService = new SearchRequestService(requestRepo);

                var searchRequestDb = fakerRequest.Generate(1).First();
                var title = searchRequestDb.Title;

                requestService.Save(searchRequestDb);
                requestService.Save(fakerRequest.Generate(1).First());
                requestService.Save(fakerRequest.Generate(1).First());

                var result = requestService.Exists(searchRequestDb);

                result.Should().BeTrue();
            }
        }

        [Test, Category("SearchRequest")]
        public void Test_SearchRequest_Exists_False()
        {
            using (var context = new YoutubeContext())
            {
                var requestRepo = new SearchRequestsRepository(context);
                var requestService = new SearchRequestService(requestRepo);

                var searchRequestDb = fakerRequest.Generate(1).First();
                var title = searchRequestDb.Title;

                requestService.Save(fakerRequest.Generate(1).First());
                requestService.Save(fakerRequest.Generate(1).First());

                var result = requestService.Exists(searchRequestDb);

                result.Should().BeFalse();
            }
        }
    }
}
