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
    public class CourseDbRepositoryTest
    {
        Mock<PresentationsContext> _mockContext;

        List<CourseDB> _fakeCourses;

        Faker<CourseDB> _fake = new Faker<CourseDB>().RuleFor(x => x.Name, y => y.Name.JobTitle())
                                                     .RuleFor(x => x.Update, DateTime.Now);

        Faker<PresentationDB> _fakePresentation = new Faker<PresentationDB>().RuleFor(x => x.Title, y => y.Name.JobTitle())
                                                                     .RuleFor(x => x.DateUpdate, DateTime.Now)
                                                                     .RuleFor(x => x.IsAccessible, y => y.Random.Bool());

        [OneTimeSetUp]
        public void Starter()
        {
            _mockContext = new Mock<PresentationsContext>();
            _fakeCourses = _fake.Generate(3);

            _mockContext.Setup(_ => _.Courses).Returns(_fakeCourses);
        }

        [Test]
        public void AddCourseTestAsync()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                List<CourseDB> forAdd = _fake.Generate(1);
                var course = forAdd.FirstOrDefault();

                Assert.IsFalse(_fakeCourses.Contains(course));

                _mockContext.Setup(_ => _.Courses.Add(It.IsAny<CourseDB>()))
                            .Returns((CourseDB c) =>
                            {
                                _fakeCourses.Add(c);
                                return c;
                            });

                uow.Courses.Add(course);

                _mockContext.Verify(_ => _.Courses.Add(It.IsAny<CourseDB>()), Times.Once());
                Assert.IsTrue(_fakeCourses.Contains(course));
            }
        }

        [Test]
        public async Task GetCourseByIdAsyncTest()
        {

            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var course = _fakeCourses.FirstOrDefault();

                var gettedCourse = await uow.Courses.GetByIdAsync(course.Id);

                course.Should().BeEquivalentTo(gettedCourse);
            }
        }

        [Test]
        public async Task GetAllCoursesAsyncTest()
        {
            using (var uow = new UnitOfWorkRepository(_mockContext.Object))
            {
                var courses = await uow.Courses.GetAllAsync();

                Assert.AreEqual(_fakeCourses, courses);
            }
        }
    }
}
