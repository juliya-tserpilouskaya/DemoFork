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
        [Test]
        public void Test_SearchVideo()
        {
            var youtubeContext = new YoutubeContext();
            using (var srRepo = new SearchRequestsRepository(youtubeContext))
            {
                var srService = new SearchRequestService(srRepo);
                var srController = new SearchRequestController(srService);

                var searchRequest = new SearchRequest();
                searchRequest.Title = "2015 05 03 Открытое занятие";

                var resultListVideo = 
                    (OkNegotiatedContentResult<IEnumerable<ResultVideoDb>>)srController.SearchRun(searchRequest);

                var result = resultListVideo.Content.ToList();
                result.Should().NotBeNullOrEmpty();
                result.Should().HaveCount(c => c > 3);
                result.First().Title.Should().Be("2015 05 03  Открытое занятие 8");
            }
        }
    }
}
