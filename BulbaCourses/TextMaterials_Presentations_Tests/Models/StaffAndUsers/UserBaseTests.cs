using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulbaCourses.TextMaterials_Presentations.Web.Models.StaffAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;

namespace TextMaterials_Presentations_Tests.Models.StaffAndUsers
{
    [TestFixture]
    public class UserBaseTests
    {
        Faker<User> _faker = new Faker<User>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.FullName, y => y.Name.FullName())
                                                   .RuleFor(x => x.UserName, y => y.Name.FirstName())
                                                   .RuleFor(x => x.Email, y => y.Internet.Email())
                                                   .RuleFor(x => x.IsPaid, y=> y.Random.Bool());
         List<User> _fakeUsers;

        [SetUp]
        public void ListGenerator() //if everyone test is failed - check the Add method
        {
            _fakeUsers = _faker.Generate(5);

            foreach (var item in _fakeUsers)
            {
                UserBase.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakeUsers)
            {
                UserBase.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<User> employees = _faker.Generate(5);

            foreach (var item in employees)
            {
                UserBase.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            UserBase.GetAll().Should().BeEquivalentTo(_fakeUsers);
        }

        [Test]
        public void GetById_Test()
        {
            UserBase.GetById(_fakeUsers.First<User>().Id).Should().BeEquivalentTo(_fakeUsers.First<User>());
        }

        [Test]
        public void Update_Test()
        {
            User userForUpdate = new User()
            {
                Id = _fakeUsers.First<User>().Id,
                FullName = "1",
                UserName = "1",
                Email = "1"
            };

            User employeeBeforeUpdate = UserBase.GetById(_fakeUsers.First<User>().Id);
            User employeeAfterUpdate = UserBase.Update(userForUpdate);

            employeeAfterUpdate.UserName.Should().BeEquivalentTo(userForUpdate.UserName);
        }

        [Test]
        public void DeleteById_Test()
        {
            UserBase.DeleteById(_fakeUsers.First<User>().Id).Should().BeTrue();
            UserBase.GetById(_fakeUsers.First<User>().Id).Should().BeNull();
        }
    }
}