using NUnit.Framework;
using BulbaCourses.Podcasts.Logic.Models;
using BulbaCourses.Podcasts.Logic.Services;
using BulbaCourses.Podcasts.Web.Controllers;

namespace BulbaCourses.Podcasts.Web.Controllers.Tests
{// do service instead
    [TestFixture()]
    public class ManageControllerTests
    {
        [Test()]
        public void GetByIdTest()
        {
            var manage = new ManageService();
            var controller = new ManageController(manage);

            var result = controller.GetById("2") as Course;
            Assert.IsNotNull(result);
        }

        [Test()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}