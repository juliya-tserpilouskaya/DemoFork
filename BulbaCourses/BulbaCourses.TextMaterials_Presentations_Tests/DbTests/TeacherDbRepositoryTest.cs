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
    public class TeacherDbRepositoryTest
    {
        Mock<PresentationsContext> _mockContext;

        List<TeacherDB> _fakeTeachers;

        Faker<TeacherDB> _fake = new Faker<TeacherDB>().RuleFor(x => x.PhoneNumber, y => y.Phone.PhoneNumber())
                                                              .RuleFor(x => x.Created, DateTime.Now)
                                                              .RuleFor(x => x.Position, y => y.Company.CompanyName());

        [OneTimeSetUp]
        public void Starter()
        {
            _mockContext = new Mock<PresentationsContext>();
            _fakeTeachers = _fake.Generate(3);

            _mockContext.Setup(_ => _.Teachers).Returns(_fakeTeachers);
        }

        [Test]
        public void AddTeacherTestAsync()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                List<TeacherDB> forAdd = _fake.Generate(1);
                var teacher = forAdd.FirstOrDefault();

                Assert.IsFalse(_fakeTeachers.Contains(teacher));

                _mockContext.Setup(_ => _.Teachers.Add(It.IsAny<TeacherDB>()))
                            .Returns((TeacherDB c) =>
                            {
                                _fakeTeachers.Add(c);
                                return c;
                            });

                uow.Teachers.Add(teacher);

                _mockContext.Verify(_ => _.Teachers.Add(It.IsAny<TeacherDB>()), Times.Once());
                Assert.IsTrue(_fakeTeachers.Contains(teacher));
            }
        }

        [Test]
        public async Task GetTeacherByIdAsyncTest()
        {

            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var teacher = _fakeTeachers.FirstOrDefault();

                var gettedTeacher = await uow.Teachers.GetByIdAsync(teacher.Id);

                teacher.Should().BeEquivalentTo(gettedTeacher);
            }
        }

        [Test]
        public async Task GetAllTeachersAsyncTest()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var teachers = await uow.Teachers.GetAllAsync();

                Assert.AreEqual(_fakeTeachers, teachers);
            }
        }
    }
}
