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

namespace TextMaterials_Presentations_Tests.Models.StaffAndUsers
{
    [TestFixture]
    public class StudentsBaseTests
    {
        Faker<Student> _faker = new Faker<Student>().RuleFor(x => x.Id, y => y.Random.Byte(0, 250).ToString())
                                                   .RuleFor(x => x.FullName, y => y.Name.FullName())
                                                   .RuleFor(x => x.UserName, y => y.Name.FirstName())
                                                   .RuleFor(x => x.Email, y => y.Internet.Email())
                                                   .RuleFor(x => x.IsPaid, y=> y.Random.Bool());
         List<Student> _fakeStudents;

        [SetUp]
        public void ListGenerator() //if everyone test are failed - check the Add method
        {
            _fakeStudents = _faker.Generate(5);

            foreach (var item in _fakeStudents)
            {
                StudentsBase.Add(item);
            }
        }

        [TearDown]
        public void Zeroing()
        {
            foreach (var item in _fakeStudents)
            {
                StudentsBase.DeleteById(item.Id);
            }
        }

        [Test]
        public void Add_Test()
        {
            List<Student> students = _faker.Generate(5);

            foreach (var item in students)
            {
                StudentsBase.Add(item).Should().BeEquivalentTo(item);
            }
        }

        [Test]
        public void GetAll_Test()
        {
            StudentsBase.GetAll().Should().BeEquivalentTo(_fakeStudents);
        }

        [Test]
        public void GetById_Test()
        {
            StudentsBase.GetById(_fakeStudents.First<User>().Id).Should().BeEquivalentTo(_fakeStudents.First<User>());
        }

        [Test]
        public void Update_Test()
        {
            Student studentForUpdate = new Student()
            {
                Id = _fakeStudents.First<User>().Id,
                FullName = "1",
                UserName = "1",
                Email = "1"
            };

            Student studentAfterUpdate = StudentsBase.Update(studentForUpdate);

            studentAfterUpdate.UserName.Should().BeEquivalentTo(studentForUpdate.UserName);
        }

        [Test]
        public void DeleteById_Test()
        {
            StudentsBase.DeleteById(_fakeStudents.First<User>().Id).Should().BeTrue();
            StudentsBase.GetById(_fakeStudents.First<User>().Id).Should().BeNull();
        }
    }
}