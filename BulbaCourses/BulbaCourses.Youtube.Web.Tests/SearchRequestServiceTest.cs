using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Web.DataAccess;
using BulbaCourses.Youtube.Web.DataAccess.Repositories;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using BulbaCourses.Youtube.Web.Logic.Services;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    class SearchRequestServiceTest
    {
        Faker<SearchRequestDb> fakerRequest;
        Faker<SearchStoryDb> fakerStory;

        [OneTimeSetUp]
        public void Init()
        {
            fakerRequest = new Faker<SearchRequestDb>();
            fakerRequest.RuleFor(r => r.Title, f => f.Random.Word());
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
