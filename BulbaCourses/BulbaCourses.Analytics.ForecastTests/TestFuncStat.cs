using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Forecast.Tests
{
    [TestFixture]
    public class TestFuncStat
    {
        private IEnumerable<double> _data;

        [SetUp]
        public void TestStart()
        {
            _data = TestData.DataDoubles();
        }

        [Test]
        public void TestCount()
        {
           var count = FuncStat.Count(_data);
           count.Should().Be(12);
        }

        [Test]
        public void TestStandardDeviation()
        {
            var count = FuncStat.StandardDeviation(_data);

            count.Should().Be(7319.0514593867629);
        }
    }
}
