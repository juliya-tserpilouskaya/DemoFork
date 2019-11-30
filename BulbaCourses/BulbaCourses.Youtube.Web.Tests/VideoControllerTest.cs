using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Web.Controllers;
using System.Net;
using System.Web.Http.Results;
using BulbaCourses.Youtube.Web.Models;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using BulbaCourses.Youtube.Web.Logic.Services;
using BulbaCourses.Youtube.Web.DataAccess.Models;
using Video = BulbaCourses.Youtube.Web.DataAccess.Models.Video;
using Course = BulbaCourses.Youtube.Web.DataAccess.Models.Course;
using CourseOwner = BulbaCourses.Youtube.Web.DataAccess.Models.CourseOwner;
using Channel = BulbaCourses.Youtube.Web.DataAccess.Models.Channel;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    public class VideoControllerTest
    {
        List<Video> videos;

        [OneTimeSetUp]
        public void Init()
        {
            //Faker for Course
            Faker<Course> fakerC = new Faker<Course>();
            fakerC.RuleFor(v => v.Id, f => f.Random.Number(1,100))
                .RuleFor(v => v.Name, f => f.Random.Words(3));

            //Faker for CourseOwner
            Faker<CourseOwner> fakerCO = new Faker<CourseOwner>();
            fakerCO.RuleFor(v => v.Id, f => f.Random.Guid().ToString())
                .RuleFor(v => v.Login, f => f.Internet.UserName())
                .RuleFor(v => v.Password, f => f.Random.String(8))
                .RuleFor(v => v.FirstName, f => f.Name.FirstName())
                .RuleFor(v => v.LastName, f => f.Name.LastName())
                .RuleFor(v => v.FullName, f => f.Name.FullName())
                .RuleFor(v => v.NumberPhone, f => f.Phone.PhoneNumber("+###(##)###-##-##"))
                .RuleFor(v => v.Email, f => Enumerable.Range(1, 3).Select(_ => f.Internet.Email()).ToList())
                .RuleFor(v => v.ChannelList, f => new List<Channel>())
                .RuleFor(v => v.Courses, f => new List<Course>());

            //Faker for Video
            int? videoIds = 0;
            Faker<Video> fakerV = new Faker<Video>();
            fakerV.RuleFor(v => v.Id, f => videoIds+1)
                .RuleFor(v => v.Title, f => f.Random.Word())
                .RuleFor(v => v.Description, f => f.Random.Words(5))
                .RuleFor(v => v.Author, f => fakerCO.Generate())
                .RuleFor(v => v.ChannelId, f => f.Random.Number(1, 5))
                .RuleFor(v => v.PlayListId, f => f.Random.Number(1, 10))
                .RuleFor(v => v.PublishedAt, f => f.Date.Past(2))
                .RuleFor(v => v.Url, f => f.Internet.Url())
                .RuleFor(v => v.Course, f => fakerC.Generate());

            videos = fakerV.Generate(5);
            
        }

        [Test]
        public void Test_GetById()
        {
            var mock = new Mock<IVideoService>();
            mock.Setup(v => v.GetById(1)).Returns(videos.First());

            VideoController videoController = new VideoController(mock.Object);

            var result = (OkNegotiatedContentResult<Video>)videoController.GetById(1);
            result.Content.Should().Be(videos.First());
        }
        [Test]
        public void Test_GetAll()
        {
            var mock = new Mock<IVideoService>();
            mock.Setup(v => v.GetAll()).Returns((IEnumerable<Video>)videos.AsReadOnly());

            VideoController videoController = new VideoController(mock.Object);

            var result = (OkNegotiatedContentResult<IEnumerable<Video>>)videoController.GetAll();
            result.Content.Should().BeEquivalentTo((IEnumerable<Video>)videos.AsReadOnly());
        }

    }
}
