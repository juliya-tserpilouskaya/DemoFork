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

namespace BulbaCourses.GlobalSearch.Tests.SearchQueries
{
    [TestFixture]
    public class SearchQueryTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

        }

        [Test]
        public void remove_all_search_queries()
        {
            //Arrange

            var kernel = new StandardKernel();
            kernel.Load<AutoMapperModule>();

            var mapper = kernel.Get<IMapper>();

            #region
            IList<SearchQueryDB> queries = new List<SearchQueryDB>()
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
            };
            #endregion

            var mockContext = new Mock<GlobalSearchContext>();
            var mockSet = new Mock<DbSet<SearchQueryDB>>();
            mockContext.Setup(x => x.SearchQueries).Returns(queries);
            var DbService = new SearchQueryDbService(mockContext.Object);
            var mockLogicService = new Mock<SearchQueryService>();

            var service = new SearchQueryService(mapper, DbService);

            //Act
            var b = new SearchQueryDTO
            {
                Id = "1",
                Date = DateTime.Now,
                Query = "search query"
            };

            var q = service.Add(b);

            var all = DbService.GetAll().Count();

            //Assert
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(q.Query, b.Query);
        }
    }
}
