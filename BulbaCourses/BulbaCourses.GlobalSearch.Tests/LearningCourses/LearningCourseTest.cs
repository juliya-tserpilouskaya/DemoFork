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
    /// Summary description for LearningCourseTest
    /// </summary>
    [TestFixture]
    public class LearningCourseTest
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
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.Provider).Returns(courses.Provider);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.Expression).Returns(courses.Expression);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.ElementType).Returns(courses.ElementType);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.GetEnumerator()).Returns(courses.GetEnumerator());

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.Courses).Returns(mockSet.Object);
        }

        //[Test, Category("LearningCourse")]
        //public void add_learning_course()
        //{

        //    var DbService = new CourseDbService(mockContext.Object);
        //    var mockLogicService = new Mock<LearningCourseService>();
        //    var service = new LearningCourseService(mapper, DbService);

        //    //Act
        //    var b = new LearningCourseDTO
        //    {
        //        Id = "1",
        //        Name = "Name"
        //    };
        //    var q = service.Add(b);
        //    var all = DbService.GetAllCourses().Count();

        //    //Assert
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());
        //    Assert.AreEqual(q.Name, b.Name);
        //}

        [Test, Category("LearningCourse")]
        public void get_all_courses()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var x = service.GetAllCourses();
            //Assert
            Assert.AreEqual(x.Count(), courses.Select(p => p).ToList().Count());
        }

        [Test, Category("LearningCourse")]
        public void get_course_by_id()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var x = service.GetById("123");
            //Assert
            Assert.AreEqual(x.Id, "123");
        }

        [Test, Category("LearningCourse")]
        public void get_course_by_authorId()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var x = service.GetByAuthorId(1).First();
            //Assert
            Assert.AreEqual(x.AuthorId, 1);
        }

        [Test, Category("LearningCourse")]
        public void remove_course_by_id()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            service.DeleteById("1");
            //Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockSet.Verify(m => m.Remove(It.IsAny<CourseDB>()), Times.Once());
        }
    }
}
