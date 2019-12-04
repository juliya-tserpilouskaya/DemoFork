using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Web.Logic.Services;
using BulbaCourses.Youtube.Web.Controllers;
using System.Collections.Generic;
using BulbaCourses.Youtube.Web.Logic.Models;
using BulbaCourses.Youtube.Web.Models;

using System.Web.Http.Results;
using Video = BulbaCourses.Youtube.Web.Models.Video;
using System.Linq;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    class VideoServiceTest
    {
        [Test]
        public void Test_GetAllVideo()
        {
            VideoController videoController = new VideoController(new VideoService());
            var searchTerm = "2015 05 03 Открытое занятие";
            var resultListVideo = (OkNegotiatedContentResult<IEnumerable<string>>)videoController.SearchVideo(searchTerm);

            var result = resultListVideo.Content.ToList();
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(c => c > 3);
        }
    }
}
