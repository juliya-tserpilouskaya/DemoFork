using System;
using System.Text;
using System.Collections.Generic;
using AutoMapper;
using BulbaCourses.GlobalSearch.Data;
using BulbaCourses.GlobalSearch.Data.Models;
using BulbaCourses.GlobalSearch.Data.Services;
using BulbaCourses.GlobalSearch.Logic;
using BulbaCourses.GlobalSearch.Logic.DTO;
using BulbaCourses.GlobalSearch.Logic.InterfaceServices;
using BulbaCourses.GlobalSearch.Logic.Services;
using Moq;
using Ninject;
using Moq.EntityFramework.Helpers;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace BulbaCourses.GlobalSearch.Tests.LearningCourses
{
    /// <summary>
    /// Summary description for LearningCourseAsyncTest
    /// </summary>
    [TestFixture]
    public class LearningCourseAsyncTest
    {
        StandardKernel kernel;
        IMapper mapper;
        IQueryable<CourseDB> courses;
        Mock<GlobalSearchContext> mockContext;
        Mock<DbSet<CourseDB>> mockSet;

        [OneTimeSetUp]
        public void Setup()
        {
            kernel = new StandardKernel();
            kernel.Load<AutoMapperModule>();
            mapper = kernel.Get<IMapper>();
        }

        [SetUp]
        public void setupMocks()
        {
            courses = new List<CourseDB>()
            {
                new CourseDB
                {
                    Id = "123",
                    Created = DateTime.Now,
                    AuthorDBId = 1
                },
                new CourseDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                },
                new CourseDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                },
                new CourseDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                },
            }.AsQueryable();

            mockSet = new Mock<DbSet<CourseDB>>();

            mockSet.As<IDbAsyncEnumerable<CourseDB>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<CourseDB>(courses.GetEnumerator()));

            mockSet.As<IQueryable<CourseDB>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<CourseDB>(courses.Provider));

            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.Expression).Returns(courses.Expression);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.ElementType).Returns(courses.ElementType);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.GetEnumerator()).Returns(courses.GetEnumerator());

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.Courses).Returns(mockSet.Object);
        }


        [Test, Category("Course")]
        public async Task get_all_courses_async()
        {
            //Arrage
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var q = await service.GetAllCoursesAsync();

            //Assert
            Assert.AreEqual(courses.Select(p => p).ToList().Count(), q.Count());
        }

        [Test, Category("Course")]
        public async Task get_course_by_id_async()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var x = await service.GetByIdAsync("123");
            //Assert
            Assert.AreEqual(x.Id, "123");
        }

        [Test, Category("Course")]
        public async Task get_course_by_authorId_async()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var x = await service.GetByAuthorIdAsync(1);
            //Assert
            Assert.AreEqual(1, x.Count());
        }
    }
}
