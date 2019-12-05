using System;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Bogus;
using BulbaCourses.Youtube.Web.Controllers;
using System.Net;
using System.Web.Http.Results;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using BulbaCourses.Youtube.Web.Logic.Services;
using BulbaCourses.Youtube.Web.DataAccess.Models;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    public class VideoControllerTest
    {
        List<ResultVideoDb> videos;

        [OneTimeSetUp]
        public void Init()
        {
            //Faker for Course
            Faker<CourseDb> fakerC = new Faker<CourseDb>();
            fakerC.RuleFor(v => v.Id, f => f.Random.Number(1,100))
                .RuleFor(v => v.Name, f => f.Random.Words(3));

            //Faker for MentorDb
            int? MentorIds = 0;
            Faker<MentorDb> fakerCO = new Faker<MentorDb>();
            fakerCO.RuleFor(v => v.Login, f => f.Internet.UserName())
                .RuleFor(v => v.Password, f => f.Random.String(8))
                .RuleFor(v => v.FirstName, f => f.Name.FirstName())
                .RuleFor(v => v.LastName, f => f.Name.LastName())
                .RuleFor(v => v.FullName, f => f.Name.FullName())
                .RuleFor(v => v.NumberPhone, f => f.Phone.PhoneNumber("+###(##)###-##-##"))
                .RuleFor(v => v.Email, f => f.Internet.Email())
                .RuleFor(v => v.Channels, f => new List<ChannelDb>());
                //.RuleFor(v => v.Courses, f => new List<Course>());

            //Faker for Video
            int? videoIds = 0;
            Faker<ResultVideoDb> fakerV = new Faker<ResultVideoDb>();
            fakerV.RuleFor(v => v.Id, f => videoIds + 1)
                .RuleFor(v => v.Title, f => f.Random.Word())
                .RuleFor(v => v.Description, f => f.Random.Words(5))
                .RuleFor(v => v.Channel, f => new ChannelDb())
                .RuleFor(v => v.PublishedAt, f => f.Date.Past(2))
                .RuleFor(v => v.Url, f => f.Internet.Url());
                // .RuleFor(v => v.PlayListId, f => f.Random.Number(1, 10))
                // .RuleFor(v => v.Author, f => fakerCO.Generate())
                // .RuleFor(v => v.Course, f => fakerC.Generate());

            videos = fakerV.Generate(5);
            
        }

        [Test]
        public void Test_GetById()
        {
            var mock = new Mock<IVideoService>();
            mock.Setup(v => v.GetById(1)).Returns(videos.First());

            VideoController videoController = new VideoController(mock.Object);

            var result = (OkNegotiatedContentResult<ResultVideoDb>)videoController.GetById(1);
            result.Content.Should().Be(videos.First());
        }
        [Test]
        public void Test_GetAll()
        {
            var mock = new Mock<IVideoService>();
            mock.Setup(v => v.GetAll()).Returns((IEnumerable<ResultVideoDb>)videos.AsReadOnly());

            VideoController videoController = new VideoController(mock.Object);

            var result = (OkNegotiatedContentResult<IEnumerable<ResultVideoDb>>)videoController.GetAll();
            result.Content.Should().BeEquivalentTo((IEnumerable<ResultVideoDb>)videos.AsReadOnly());
        }

    }
}
