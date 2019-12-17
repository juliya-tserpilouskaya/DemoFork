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
using Ninject;
using BulbaCourses.Youtube.Web.Logic;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    class SearchRequestControllerTest
    {
        SearchRequestController srController;

        [OneTimeSetUp]
        public void Init()
        {
            var kernel = new StandardKernel();
            kernel.Load<LogicModule>();

           // var youtubeContext = new YoutubeContext();

            var lService = new LogicService(kernel.Get<IServiceFactory>());

            srController = new SearchRequestController(lService);
        }

        [Test]
        public void Test_SearchVideo()
        {
            var searchRequest = new SearchRequest();
            searchRequest.Title = "2015 05 03 Открытое занятие";
            searchRequest.PublishedAfter = DateTime.Now.AddYears(-10);
            searchRequest.PublishedBefore = DateTime.Now;

            var resultListVideo =
                (OkNegotiatedContentResult<IEnumerable<ResultVideo>>)srController.SearchRun(searchRequest)
                .GetAwaiter().GetResult();

            var result = resultListVideo.Content.ToList();

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(c => c > 3);
            result.First().Title.Should().Be("2015 05 03  Открытое занятие 8");
        }
    }
}
