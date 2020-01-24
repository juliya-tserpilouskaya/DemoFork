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
            
            IForecastModel forecastModel = new ForecastModel(_data, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyHistoric().Sum(_ =>_.Value);
            data.Should().Be(2277832);
        }

        [Test()]
        public void GetDataForecastTest()
        {

            IForecastModel forecastModel = new ForecastModel(_data, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyForecast().Sum(_ => _.Value);
            data.Should().Be(1190393);
        }

        [Test()]
        public void GetDataForecastOptimisticTest()
        {

            IForecastModel forecastModel = new ForecastModel(_data, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyForecastOptimistic().Sum(_ => _.Value);
            data.Should().Be(1240085);
        }

        [Test()]
        public void GetDataForecastPessimisticTest()
        {

            IForecastModel forecastModel = new ForecastModel(_data, 12, Scheme.Period.Month);

            var data = forecastModel.GetData().GetOnlyForecastPessimistic().Sum(_ => _.Value);
            data.Should().Be(1140701);
        }
    }
}