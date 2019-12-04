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
    [TestFixture]
    public class CourseBaseTest
    {
        Faker<Course> _faker = new Faker<Course>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.Name, y => y.Name.JobTitle());

        List<Course> _fakeCourses;

        [SetUp]
        public void ListGenerator() //if everyone test is failed - check the Add method
        {
            _fakeCourses = _faker.Generate(5);

            foreach (var item in _fakeCourses)
            {
                CourseBase.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakeCourses)
            {
                CourseBase.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Course> courses = _faker.Generate(5);

            foreach (var item in courses)
            {
                CourseBase.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            CourseBase.GetAll().Should().BeEquivalentTo(_fakeCourses);
        }

        [Test]
        public void GetById_Test()
        {
            CourseBase.GetById(_fakeCourses.First<Course>().Id).Should().BeEquivalentTo(_fakeCourses.First<Course>());
        }

        [Test]
        public void Update_Test()
        {
            Course courseForUpdate = new Course()
            {
                Id = _fakeCourses.First<Course>().Id,
                Name = "1",
            };

            Course courseAfterUpdate = CourseBase.Update(courseForUpdate);

            courseAfterUpdate.Name.Should().BeEquivalentTo(courseForUpdate.Name);
        }

        [Test]
        public void DeleteById_Test()
        {
            CourseBase.DeleteById(_fakeCourses.First<Course>().Id).Should().BeTrue();
            CourseBase.GetById(_fakeCourses.First<Course>().Id).Should().BeNull();
        }
    }
}
