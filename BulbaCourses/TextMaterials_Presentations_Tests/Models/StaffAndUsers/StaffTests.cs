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

namespace BulbaCourses.TextMaterials_Presentations.Tests
{
    [TestFixture]
    public class StaffTests
    {
        Faker<Teacher> _faker = new Faker<Teacher>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                        .RuleFor(x => x.FullName, y => y.Name.FullName())
                                                        .RuleFor(x => x.UserName, y => y.Name.FirstName())
                                                        .RuleFor(x => x.Email, y => y.Internet.Email());
        List<Teacher> _fakeEmployees;

        [SetUp]
        public void ListGenerator() //if everyone test is failed - check the Add method
        {
            _fakeEmployees = _faker.Generate(5);

            foreach (var item in _fakeEmployees)
            {
                Staff.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakeEmployees)
            {
                Staff.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Teacher> employees = _faker.Generate(5);

            foreach (var item in employees)
            {
                Staff.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            Staff.GetAll().Should().BeEquivalentTo(_fakeEmployees);
        }

        [Test]
        public void GetById_Test()
        {
            Staff.GetById(_fakeEmployees.First<Teacher>().Id).Should().BeEquivalentTo(_fakeEmployees.First<Teacher>());
        }

        [Test]
        public void Update_Test()
        {
            Teacher employeeForUpdate = new Teacher()
            {
                Id = _fakeEmployees.First<Teacher>().Id,
                FullName = "1",
                UserName = "1",
                Email = "1"
            };

            Teacher employeeBeforeUpdate = Staff.GetById(_fakeEmployees.First<Teacher>().Id);
            Teacher employeeAfterUpdate = Staff.Update(employeeForUpdate);

            employeeAfterUpdate.UserName.Should().BeEquivalentTo(employeeForUpdate.UserName);
        }

        [Test]
        public void DeleteById_Test()
        {
            Staff.DeleteById(_fakeEmployees.First<Teacher>().Id).Should().BeTrue();
            Staff.GetById(_fakeEmployees.First<Teacher>().Id).Should().BeNull();
        }
    }
}