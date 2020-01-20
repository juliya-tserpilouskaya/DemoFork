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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
        IQueryable<CourseDB> queries;
        Mock<GlobalSearchContext> mockContext;
        Mock<DbSet<CourseDB>> mockSet;
        Mock<DbSet<CourseItemDB>> mockSetItem;


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
            queries = new List<CourseDB>()
            {
                new CourseDB
                {
                    Id = "123",
                    Created = DateTime.Now,
                    Items = new List<CourseItemDB>
                    {
                        new CourseItemDB
                        {
                            Id = "1",
                            Name = "Item",
                            Description = "Description",
                            CourseDBId = "123"
                        }
                    },
                    AuthorDBId = 1
                },
                new CourseDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Items = new List<CourseItemDB>
                    {
                        new CourseItemDB
                        {
                            Id = "2",
                            Name = "Item",
                            Description = "Description"
                        }
                    }, 
                    Complexity = "easy"
                },
                new CourseDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Items = new List<CourseItemDB>
                    {
                        new CourseItemDB
                        {
                            Id = "2",
                            Name = "Item",
                            Description = "Description"
                        }
                    },
                    AuthorDBId = 2,
                    Complexity = "easy"
                },
                new CourseDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Complexity = "easy",
                    Items = new List<CourseItemDB>
                    {
                        new CourseItemDB
                        {
                            Id = "3",
                            Name = "Item",
                            Description = "Description"
                        }
                    }
                },
            }.AsQueryable();

            mockSet = new Mock<DbSet<CourseDB>>();
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.Provider).Returns(queries.Provider);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.Expression).Returns(queries.Expression);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.ElementType).Returns(queries.ElementType);
            mockSet.As<IQueryable<CourseDB>>().Setup(m => m.GetEnumerator()).Returns(queries.GetEnumerator());

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.Courses).Returns(mockSet.Object);
        }

        [Test, Category("Course")]
        public void get_all_courses()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);
            //Act
            var x = service.GetAllCourses();
            //Assert
            Assert.AreEqual(x.Count(), queries.Select(p => p).ToList().Count());
        }

        [Test, Category("Course")]
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

        [Test, Category("Course")]
        public void get_course_by_authorId()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var x = service.GetByAuthorId(2).FirstOrDefault();
            //Assert
            Assert.AreEqual(2, x.AuthorId);
        }

        [Test, Category("Course")]
        public void remove_course_by_id()
        {
            mockSetItem = new Mock<DbSet<CourseItemDB>>();
            mockContext.Setup(x => x.CourseItems).Returns(mockSetItem.Object);
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            //Act
            var result = service.DeleteById("123");
            //Assert
            Assert.IsTrue(result);
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            mockSet.Verify(m => m.Remove(It.IsAny<CourseDB>()), Times.Once());
            mockSetItem.Verify(m => m.RemoveRange(It.IsAny<IEnumerable<CourseItemDB>>()), Times.Once());
        }

        [Test, Category("Course")]
        public void update_course()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            LearningCourseDTO lc = new LearningCourseDTO
            {
                Name = "Course",
                Id = "123",
                Category = 2,
                Cost = 10,
                Language = "EN"
            };
            //Act
            var x = service.UpdateNoIndex(lc);
            //Assert
            Assert.AreEqual(queries.First().Id, lc.Id);
            Assert.AreEqual(queries.Count(), queries.Count());

        }

        [Test, Category("Course")]
        public void add_course()
        {
            var DbService = new CourseDbService(mockContext.Object);
            var mockLogicService = new Mock<LearningCourseService>();
            var service = new LearningCourseService(mapper, DbService);

            LearningCourseDTO lc = new LearningCourseDTO
            {
                Name = "Course",
                Id = "33",
                Category = 2,
                Cost = 10,
                Language = "EN"
            };
            //Act
            var x = service.AddNoIndex(lc);
            //Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
