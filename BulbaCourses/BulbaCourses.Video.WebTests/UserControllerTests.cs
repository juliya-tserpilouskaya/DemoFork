using Bogus;
using BulbaCourses.Video.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BulbaCourses.Video.WebTests
{
    [TestFixture]
    public class UserControllerTests
    {
        List<UserDb> users;

        [OneTimeSetUp]
        public void Init()
        {
            Faker<UserDb> fakerUsers = new Faker<UserDb>();
            fakerUsers.RuleFor(u => u.UserId, b => b.Random.String(8))
                .RuleFor(u => u.Name, b => b.Name.FirstName())
                .RuleFor(u => u.LastName, b => b.Name.LastName())
                .RuleFor(u => u.Login, b => b.Internet.UserName())
                .RuleFor(u => u.Password, b => b.Random.String(10))
                .RuleFor(u => u.Email, b => b.Internet.Email())
                .RuleFor(u => u.AvatarPath, b => b.Internet.Avatar())
                .RuleFor(u => u.SubscriptionType, b => b.Random.Int(0, 3));

            users = fakerUsers.Generate(10);
        }

        [Test]
        public void TestMethod1()
        {
        }
    }
}
