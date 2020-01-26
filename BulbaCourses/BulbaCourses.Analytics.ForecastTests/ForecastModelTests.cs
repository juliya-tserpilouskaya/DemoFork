using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Forecast.Tests
{
    [TestFixture()]
    public class ForecastModelTests
    {
        private Data[] _data;

        [SetUp]
        public void TestStart()
        {
            _data = TestData.Data();
        }

        [Test()]
        public void GetDataHistoricTest()
        {
            
            IForecastModel forecastModel = new ForecastModel(_data, 12, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyHistoric(3).Sum(_ =>_.Value);
            data.Should().Be(292594);
        }

        [Test()]
        public void GetDataForecastTest()
        {

            IForecastModel forecastModel = new ForecastModel(_data, 12, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyForecast(3).Sum(_ => _.Value);
            data.Should().Be(290160);
        }

        [Test()]
        public void GetDataForecastOptimisticTest()
        {

            IForecastModel forecastModel = new ForecastModel(_data,12, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyForecastOptimistic(3).Sum(_ => _.Value);
            data.Should().Be(302583);
        }

        [Test()]
        public void GetDataForecastPessimisticTest()
        {

            IForecastModel forecastModel = new ForecastModel(_data, 12,12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyForecastPessimistic(3).Sum(_ => _.Value);
            data.Should().Be(277737);
        }
    }
}