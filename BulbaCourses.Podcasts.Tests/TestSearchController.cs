using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulbaCourses.Podcasts.Web.Controllers;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Logic.Services;

namespace BulbaCourses.Podcasts.Tests
{
    [TestClass]
    class TestSearchController
    {
        [TestMethod]
        public void SearchTest()
        {
            SearchService service = new SearchService();
            SearchController controller = new SearchController(service);

            SearchResultList result = controller.GetSearchResults("se", SearchMode.ByTitle) as SearchResultList;
            Assert.AreEqual(2, result.Length());
        }
    }
}
