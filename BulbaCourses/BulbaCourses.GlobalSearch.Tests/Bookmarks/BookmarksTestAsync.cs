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

namespace BulbaCourses.GlobalSearch.Tests.Bookmarks
{
    public class BookmarksTestAsync
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

            mockSet.As<IDbAsyncEnumerable<BookmarkDB>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<BookmarkDB>(bookmarks.GetEnumerator()));

            mockSet.As<IQueryable<SearchQueryDB>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<BookmarkDB>(bookmarks.Provider));

            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.Expression).Returns(bookmarks.Expression);
            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.ElementType).Returns(bookmarks.ElementType);
            mockSet.As<IQueryable<BookmarkDB>>().Setup(m => m.GetEnumerator()).Returns(bookmarks.GetEnumerator());

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.Bookmarks).Returns(mockSet.Object);
        }

        [Test, Category("Bookmark")]
        public async Task get_all_bookmarks_async()
        {
            //Arrage
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var q = await service.GetAllAsync();

            //Assert
            Assert.AreEqual(bookmarks.Select(p => p).ToList().Count(), q.Count());
        }

        [Test, Category("Bookmark")]
        public async Task get_bookmark_by_id_async()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var x = await service.GetByIdAsync("123");
            //Assert
            Assert.AreEqual(x.Id, "123");
        }

        [Test, Category("Bookmark")]
        public async Task get_bookmark_by_userId_async()
        {
            var DbService = new BookmarkDbService(mockContext.Object);
            var mockLogicService = new Mock<BookmarkService>();
            var service = new BookmarkService(mapper, DbService);

            //Act
            var x = await service.GetByUserIdAsync("1");
            //Assert
            Assert.AreEqual(1, x.Count());
        }
    }
}
