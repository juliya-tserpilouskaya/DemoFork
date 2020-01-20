using BulbaCourses.TextMaterials_Presentations.Data;
using Presentations.Logic.Repositories;
using Presentations.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq.EntityFramework.Helpers;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Bogus;
using Moq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TextMaterials_Presentations_Tests.DbTests
{
    [TestFixture]
    public class StudentDbRepositoryTest
    {
        Mock<PresentationsContext> _mockContext;

        List<StudentDB> _fakeStudents;

        Faker<StudentDB> _fake = new Faker<StudentDB>().RuleFor(x => x.PhoneNumber, y => y.Phone.PhoneNumber())
                                                              .RuleFor(x => x.IsPaid, y => y.Random.Bool())
                                                              .RuleFor(x => x.Created, DateTime.Now);

        [OneTimeSetUp]
        public void Starter()
        {
            _mockContext = new Mock<PresentationsContext>();
            _fakeStudents = _fake.Generate(3);

            _mockContext.Setup(_ => _.Students).Returns(_fakeStudents);
        }

        [Test]
        public void AddStudentTestAsync()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                List<StudentDB> forAdd = _fake.Generate(1);
                var student = forAdd.FirstOrDefault();

                Assert.IsFalse(_fakeStudents.Contains(student));

                _mockContext.Setup(_ => _.Students.Add(It.IsAny<StudentDB>()))
                            .Returns((StudentDB c) =>
                            {
                                _fakeStudents.Add(c);
                                return c;
                            });

                uow.Students.Add(student);

                _mockContext.Verify(_ => _.Students.Add(It.IsAny<StudentDB>()), Times.Once());
                Assert.IsTrue(_fakeStudents.Contains(student));
            }
        }

        [Test]
        public async Task GetStudentByIdAsyncTest()
        {

            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var student = _fakeStudents.FirstOrDefault();

                var gettedStudent = await uow.Students.GetByIdAsync(student.Id);

                student.Should().BeEquivalentTo(gettedStudent);
            }
        }

        [Test]
        public async Task GetAllStudentsAsyncTest()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var students = await uow.Students.GetAllAsync();

                Assert.AreEqual(_fakeStudents, students);
            }
        }
    }
}
