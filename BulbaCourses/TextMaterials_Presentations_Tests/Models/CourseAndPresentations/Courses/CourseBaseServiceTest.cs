using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentations.Logic.Repositories;
using Presentations.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;

namespace TextMaterials_Presentations_Tests.Models.CourseAndPresentations.Courses
{
    [TestClass]
    public class CourseBaseServiceTest
    {
        List<Course> _fakeCourses;

        CourseBaseService _courseBaseService = new CourseBaseService();
        Faker<Course> _faker = new Faker<Course>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.Name, y => y.Name.JobTitle());

        [SetUp]
        public void ListGenerator() //if everyone test are failed - check the Add method
        {
            _fakeCourses = _faker.Generate(5);

            foreach (var item in _fakeCourses)
            {
                _courseBaseService.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakeCourses)
            {
                _courseBaseService.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Course> courses = _faker.Generate(5);

            foreach (var item in courses)
            {
                _courseBaseService.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            _courseBaseService.GetAll().Should().BeEquivalentTo(_fakeCourses);
        }

        [Test]
        public void GetById_Test()
        {
            _courseBaseService.GetById(_fakeCourses.First<Course>().Id).Should().BeEquivalentTo(_fakeCourses.First<Course>());
        }

        [Test]
        public void Update_Test()
        {
            Course courseForUpdate = new Course()
            {
                Id = _fakeCourses.First<Course>().Id,
                Name = "1",
            };

            Course courseAfterUpdate = _courseBaseService.Update(courseForUpdate);

            courseAfterUpdate.Name.Should().BeEquivalentTo(courseForUpdate.Name);
        }

        [Test]
        public void DeleteById_Test()
        {
            _courseBaseService.DeleteById(_fakeCourses.First<Course>().Id).Should().BeTrue();
            _courseBaseService.GetById(_fakeCourses.First<Course>().Id).Should().BeNull();
        }
    }
}
