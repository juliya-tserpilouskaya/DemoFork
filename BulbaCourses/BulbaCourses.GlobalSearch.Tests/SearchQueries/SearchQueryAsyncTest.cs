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

namespace BulbaCourses.GlobalSearch.Tests.SearchQueries
{
    /// <summary>
    /// Summary description for SearchQueryAsyncTest
    /// </summary>
    [TestFixture]
    public class SearchQueryAsyncTest
    {
        StandardKernel kernel;
        IMapper mapper;
        IQueryable<SearchQueryDB> queries;
        Mock<GlobalSearchContext> mockContext;
        Mock<DbSet<SearchQueryDB>> mockSet;

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
            queries = new List<SearchQueryDB>()
            {
                new SearchQueryDB
                {
                    Id = "123",
                    Created = DateTime.Now,
                    Query = "course that will make me smarter",
                    UserId = "1"
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Query = "basic c#"
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Query = "advanced php"
                },
                new SearchQueryDB
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Query = "beginner course"
                },
            }.AsQueryable();

            mockSet = new Mock<DbSet<SearchQueryDB>>();

            mockSet.As<IDbAsyncEnumerable<SearchQueryDB>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<SearchQueryDB>(queries.GetEnumerator()));

            mockSet.As<IQueryable<SearchQueryDB>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<SearchQueryDB>(queries.Provider));

            mockSet.As<IQueryable<SearchQueryDB>>().Setup(m => m.Expression).Returns(queries.Expression);
            mockSet.As<IQueryable<SearchQueryDB>>().Setup(m => m.ElementType).Returns(queries.ElementType);
            mockSet.As<IQueryable<SearchQueryDB>>().Setup(m => m.GetEnumerator()).Returns(queries.GetEnumerator());

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.SearchQueries).Returns(mockSet.Object);
        }


        [Test, Category("SearchQuery")]
        public async Task get_all_search_queries_async()
        {
            //Arrage
            var DbService = new SearchQueryDbService(mockContext.Object);
            var mockLogicService = new Mock<SearchQueryService>();
            var service = new SearchQueryService(mapper, DbService);

            //Act
            var q = await service.GetAllAsync();

            //Assert
            Assert.AreEqual(queries.Select(p => p).ToList().Count(), q.Count());
        }

        [Test, Category("SearchQuery")]
        public async Task get_search_query_by_id_async()
        {
            var DbService = new SearchQueryDbService(mockContext.Object);
            var mockLogicService = new Mock<SearchQueryService>();
            var service = new SearchQueryService(mapper, DbService);

            //Act
            var x = await service.GetByIdAsync("123");
            //Assert
            Assert.AreEqual(x.Id, "123");
        }

        [Test, Category("SearchQuery")]
        public async Task get_search_query_by_userId_async()
        {
            var DbService = new SearchQueryDbService(mockContext.Object);
            var mockLogicService = new Mock<SearchQueryService>();
            var service = new SearchQueryService(mapper, DbService);

            //Act
            var x = await service.GetByUserIdAsync("1");
            //Assert
            Assert.AreEqual(1, x.Count());
        }
    }
}
