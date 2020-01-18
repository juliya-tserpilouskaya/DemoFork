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
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Query = "course that will make me smarter"
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

            mockSet.As<IDbAsyncEnumerable<SearchQueryDB>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<SearchQueryDB>(queries.GetEnumerator()));

            mockSet.As<IQueryable<SearchQueryDB>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<SearchQueryDB>(queries.Provider));

            mockContext = new Mock<GlobalSearchContext>();
            mockContext.Setup(x => x.SearchQueries).Returns(mockSet.Object);
        }


        [Test, Category("SearchQuery")]
        public async Task getall_search_queries_async()
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
    }
}
