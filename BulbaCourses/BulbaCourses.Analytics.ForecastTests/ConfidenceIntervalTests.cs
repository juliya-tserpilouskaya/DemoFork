using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Forecast.Tests
{
    [TestFixture()]
    public class ConfidenceIntervalTests
    {
        private IEnumerable<double> _data;

        [SetUp]
        public void TestStart()
        {
            _data = TestData.DataDoubles();
        }

        [Test()]
        public void GetResultTest()
        {
            var confidenceInterval = new ConfidenceInterval(_data);
            confidenceInterval.Calculate();
            var result = confidenceInterval.Value;
            result.Should().Be(4141.1432036838778);
        }
    }
}