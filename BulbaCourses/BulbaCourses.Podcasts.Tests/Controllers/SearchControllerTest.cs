using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Logic.Services;
using BulbaCourses.Podcasts.Web.Controllers;
using NUnit.Framework;

namespace BulbaCourses.Podcasts.Tests
{
    [TestFixture]
    class SearchControllerTest
    {
        [Test]
        public void SearchTest()
        {
            SearchService service = new SearchService();
            SearchController controller = new SearchController(service);

            SearchResultList result = controller.GetSearchResults("se", SearchMode.ByTitle) as SearchResultList;
            Assert.IsNotNull(result);
        }
    }
}//// ITS NOT WORKING
//No courses currently
