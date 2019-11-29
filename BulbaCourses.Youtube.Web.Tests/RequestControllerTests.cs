using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using BulbaCourses.Youtube.Web.Controllers;
using BulbaCourses.Youtube.Web.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BulbaCourses.Youtube.Web.Tests
{
    [TestFixture]
    class RequestControllerTests
    {
        [Test]
        public void Can_GetAllRequests_Test()
        {
            // Организаци;
            Mock<IRequestsRepository> mock = new Mock<IRequestsRepository>();
            mock.Setup(m => m.SearchRequests).Returns((new SearchRequest[] {
                new SearchRequest() { Id =  "1", Title = "request1", VideoId = "1", UserId = "1", Url = "url1", Author = "author1", Description = "description1", Channel = "1", PlayList = "1", PublishedAt = DateTime.Now},
                new SearchRequest() { Id =  "2", Title = "request2", VideoId = "2", UserId = "2", Url = "url2", Author = "author1", Description = "description2", Channel = "2", PlayList = "2", PublishedAt = DateTime.Now}
            }).ToList());

            // Организация
            RequestController controller = new RequestController(mock.Object);

            // Действие
            var result = controller.GetRequests() as List<SearchRequest>;

            // Утверждение
            Assert.AreEqual(2, result.Count);
        }
    }
}
