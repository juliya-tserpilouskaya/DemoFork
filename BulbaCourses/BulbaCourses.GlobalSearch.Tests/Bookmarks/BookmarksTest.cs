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

namespace BulbaCourses.GlobalSearch.Tests.Bookmarks
{
    /// <summary>
    /// Summary description for BookmarksTest
    /// </summary>
    [TestFixture]
    public class BookmarksTest
    {
        StandardKernel kernel;
        IMapper mapper;
        IQueryable<BookmarkDB> bookmarks;
        Mock<GlobalSearchContext> mockContext;
        Mock<DbSet<BookmarkDB>> mockSet;

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
            bookmarks = new List<BookmarkDB>()
            {
                new BookmarkDB
                {
                    Id = "123",
                    UserId = "1"
                },
                new BookmarkDB
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new BookmarkDB
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new BookmarkDB
                {
                    Id = Guid.NewGuid().ToString(),
                },
            }.AsQueryable();

            mockSet = new Mock<DbSet<BookmarkDB>>();
            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.Provider).Returns(bookmarks.Provider);
            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.Expression).Returns(bookmarks.Expression);
            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.ElementType).Returns(bookmarks.ElementType);
            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.GetEnumerator()).Returns(bookmarks.GetEnumerator());

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.Bookmarks).Returns(mockSet.Object);
        }

        [Test, Category("Bookmark")]
        public void add_bookmark()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var b = new BookmarkDTO
            {
                Id = "1",
                Title = "Title"
            };
            var q = service.Add(b);
            var all = DbService.GetAll().Count();

            //Assert
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(q.Title, b.Title);
        }

        [Test, Category("Bookmark")]
        public void remove_all_bookmarks()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            service.RemoveAll();

            //Assert
            mockSet.Verify(m => m.RemoveRange(It.IsAny<IEnumerable<BookmarkDB>>()), Times.Once());
        }

        [Test, Category("Bookmark")]
        public void get_all_bookmarks()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var x = service.GetAll();
            //Assert
            Assert.AreEqual(x.Count(), bookmarks.Select(p => p).ToList().Count());
        }

        [Test, Category("Bookmark")]
        public void get_bookmarks_by_id()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var x = service.GetById("123");
            //Assert
            Assert.AreEqual(x.Id, "123");
        }

        [Test, Category("Bookmark")]
        public void get_bookmarks_by_userId()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var x = service.GetByUserId("1").First();
            //Assert
            Assert.AreEqual(x.UserId, "1");
        }

        [Test, Category("Bookmark")]
        public void remove_bookmarks_by_id()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            service.RemoveById("123");
            //Assert
            mockSet.Verify(m => m.Remove(It.IsAny<BookmarkDB>()), Times.Once());
        }
    }
}
