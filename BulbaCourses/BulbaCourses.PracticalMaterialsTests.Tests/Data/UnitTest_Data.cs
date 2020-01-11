using BulbaCourses.PracticalMaterialsTests.Data.Context;
using BulbaCourses.PracticalMaterialsTests.Logic.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Interfaсe;
using BulbaCourses.PracticalMaterialsTests.Logic.Services.Tests.Realization;
using NUnit.Framework;
using System.Linq;

namespace BulbaCourses.PracticalMaterialsTests.Tests.Data
{
    [TestFixture]
    public class UnitTest_Data
    {
        [OneTimeSetUp]
        public void Init()
        {
            
        }

        [Test]
        public void TestMethod1()
        {
            IService_Test ServiceTest = new Service_Test(new DbContext_Test());

            MTest_MainInfo Test_MainInfo = ServiceTest.GetTestById(1);

            Assert.Warn($@"{Test_MainInfo.Id} || {Test_MainInfo.Name}");             
        }
    }
}
