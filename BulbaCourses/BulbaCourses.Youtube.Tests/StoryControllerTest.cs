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
        Faker<SearchRequestDb> fakerRequest;
        Faker<SearchStoryDb> fakerStory;
        Faker<UserDb> fakerUser;
        UserDb user1;
        UserDb user2;
        StoryController stController;

        [OneTimeSetUp]
        public void Init()
        {
            fakerUser = new Faker<UserDb>();
            fakerUser.RuleFor(u => u.Login, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Random.String(8))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.FullName, f => f.Name.FullName())
                .RuleFor(u => u.NumberPhone, f => f.Phone.PhoneNumber("+###(##)###-##-##"))
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.ReserveEmail, f => f.Internet.Email());

            var definition = new[] { "High", "Standard", "Any" };
            var dimension = new[] { "Value2d", "Value3d", "Any" };
            var duration = new[] { "Long__", "Medium", "Short__", "Any" };
            var caption = new[] { "ClosedCaption", "None", "Any" };
            fakerRequest = new Faker<SearchRequestDb>()
                .RuleFor(r => r.Title, f => f.Random.Word())
                .RuleFor(r => r.CacheId, f => f.Random.Word())
                .RuleFor(r => r.Definition, f => f.PickRandom(definition))
                .RuleFor(r => r.Dimension, f => f.PickRandom(dimension))
                .RuleFor(r => r.Duration, f => f.PickRandom(duration))
                .RuleFor(r => r.VideoCaption, f => f.PickRandom(caption));

            fakerStory = new Faker<SearchStoryDb>();
            fakerStory.RuleFor(s => s.SearchRequest, f => fakerRequest.Generate(1).First())
                .RuleFor(s => s.SearchDate, f => f.Date.Past(1, null));

            var kernel = new StandardKernel();
            kernel.Load<LogicModule>();
            var uService = new UserService(kernel.Get<IUserRepository>());
            var stService = new StoryService(kernel.Get<IStoryRepository>());
            stController = new StoryController(stService);
            
            //generate users and stories
            user1 = uService.Save(fakerUser.Generate(1).First());
            var storyDb1 = fakerStory.Generate(3);
            foreach (var item in storyDb1)
            {
                item.User = user1;
                stService.Save(item);
            }
            user2 = uService.Save(fakerUser.Generate(1).First());
            var storyDb2 = fakerStory.Generate(5);
            foreach (var item in storyDb2)
            {
                item.User = user2;
                stService.Save(item);
            }
       }

        [Test]
        public void Test_GetStory_ByUserId()
        {
            var resultListStory =
                (OkNegotiatedContentResult<IEnumerable<SearchStory>>)stController.GetStoryByUserID(user1.Id)
                .GetAwaiter().GetResult();

            var result = resultListStory.Content.ToList();

            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(c => c == 3);

            foreach (var item in result)
                item.User.Id.Should().Be(user1.Id);
        }
    }
}
