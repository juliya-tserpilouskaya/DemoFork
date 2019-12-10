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
    public class CourseTeachersServiceTest
    {
        List<Teacher> _fakeStaff;
        Course _course;

        CourseTeachersService _courseTeachersService = new CourseTeachersService();

        Faker<Teacher> _faker = new Faker<Teacher>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.FullName, y => y.Name.FullName());

        [SetUp]
        public void ListGenerator() //if everyone test are failed - check the Add method
        {
            _course = new Course();
            _course.CourseTeachers = new List<Teacher>();

            _fakeStaff = _faker.Generate(5);

            foreach (var item in _fakeStaff)
            {
                _courseTeachersService.Add(_course, item);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Teacher> staff = _faker.Generate(5);

            foreach (var item in staff)
            {
                _courseTeachersService.Add(_course, item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            _courseTeachersService.GetAll(_course).Should().BeEquivalentTo(_fakeStaff);
        }

        [Test]
        public void GetById_Test()
        {
            _courseTeachersService.GetById(_course, _fakeStaff.First<Teacher>().Id).Should().BeEquivalentTo(_fakeStaff.First<Teacher>());
        }

        [Test]
        public void DeleteById_Test()
        {
            _courseTeachersService.DeleteById(_course, _fakeStaff.First<Teacher>().Id).Should().BeTrue();
            _courseTeachersService.GetById(_course, _fakeStaff.First<Teacher>().Id).Should().BeNull();
        }
    }
}
