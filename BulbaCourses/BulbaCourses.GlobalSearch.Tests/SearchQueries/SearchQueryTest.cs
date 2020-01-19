using BulbaCourses.GlobalSearch.Data;
using BulbaCourses.GlobalSearch.Data.Models;
using Moq;
using Moq.EntityFramework.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var mockSet = new Mock<DbSet<SearchQueryDB>>();

            var globalSearchContextMock = new Mock<GlobalSearchContext>();

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

            globalSearchContextMock.Setup(x => x.SearchQueries).Returns(queries);

            var service = new SearchQueryService(globalSearchContextMock.Object);

            //Act
            var b = new SearchQueryDB
            {
                Id = "1",
                Created = DateTime.Now,
                Query = "search query"
            };

            var q = service.Add(b);

            //Assert
            globalSearchContextMock.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(q.Id, b);
        }
    }
}
