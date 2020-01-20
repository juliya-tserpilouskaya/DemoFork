using System;
using System.Collections.Generic;
using System.Linq;
using static Forecast.Scheme;

namespace Forecast
{
    /// <summary>
    /// Represents ForecastModel.
    /// </summary>
    public class ForecastModel : IForecastModel
    {
        private int _season;
        private int _intervalForecast;
        private Period _period;
        private IEnumerable<Data> _baseData;

        /// <summary>
        /// Creates ForecastModel.
        /// </summary>
        /// <param name="baseData"></param>
        /// <param name="intervalForecast"></param>
        /// <param name="period"></param>
        public ForecastModel(IEnumerable<Data> baseData, int intervalForecast, Period period)
        {
            _season = 12;
            _period = period;
            _baseData = baseData;
            _intervalForecast = intervalForecast;
        }

        /// <summary>
        /// Forecast Data.
        /// Function: y = a + bx
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ForecastData> GetData()
        {
            var baseForecastData = _baseData.Select(
                baseData => new ForecastData(baseData.Date, baseData.Value, null, null, null)).ToList();
            var lastOrDefault = baseForecastData.LastOrDefault();
            if (lastOrDefault == null) return default;

            var lastForecastDate = lastOrDefault.Date;
            var newDate = lastForecastDate;

            var valueAvg = baseForecastData.Average(_ => _.Value);
            var dateStampAvg = baseForecastData.Average(_ => _.DateStamp);
            var countValues = baseForecastData.Count();

            var sumTop = 0d;
            var sumBottom = 0d;
            for (var i = 0; i < countValues; i++)
            {
                var deltaDate = baseForecastData[i].DateStamp - dateStampAvg;
                var deltaValue = baseForecastData[i].Value - valueAvg;
                sumTop += deltaDate * deltaValue;
                sumBottom += deltaDate * deltaDate;
            }

            var b = sumTop / sumBottom;
            var a = valueAvg - b * dateStampAvg;

            var coefficients = GetSetSeasonCoefficient().ToArray();

            for (var i = 0; i < _intervalForecast; i++)
            {
                newDate = GetNewDate(newDate);

                var forecast = Math.Round((a + b * newDate.ToOADate()) * coefficients[newDate.Month - 1]);

                baseForecastData.Add(new ForecastData(newDate, 0, forecast, null, null));
            }

            var values = baseForecastData.Where(x => x.Value == 0).Select(_ => _.Forecast ?? 0);
            var deviation = new ConfidenceInterval(values);
            deviation.Calculate();

            foreach (var forecastData in baseForecastData.Where(x => x.Value == 0))
            {
                forecastData.ForecastOptimistic = Math.Round((forecastData.Forecast ?? 0) + deviation.Value);
                forecastData.ForecastPessimistic = Math.Round((forecastData.Forecast ?? 0) - deviation.Value);
            }

            return baseForecastData;
        }

        private DateTime GetNewDate(DateTime newDate)
        {
            switch (_period)
            {
                case Period.Day:
                    newDate = newDate.AddDays(1);
                    newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day, 0, 0, 0, newDate.Kind);
                    break;
                case Period.Month:
                    newDate = newDate.AddMonths(1);
                    newDate = new DateTime(newDate.Year, newDate.Month, 1, 0, 0, 0, newDate.Kind);
                    break;
                case Period.Year:
                    newDate = newDate.AddYears(1);
                    newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day, 0, 0, 0, newDate.Kind);
                    break;
            }

            return newDate;
        }

        private IEnumerable<double> GetSetSeasonCoefficient()
        {
            var countBaseData = _baseData.Count();

            if (_season == 0) return default;
            if (countBaseData < _season) return default;

            var countSeason = (int)Math.Truncate((double)countBaseData / _season);
            var countSeasonHistory = countSeason * _season;

            var SeasonHistory = _baseData.Take(countSeasonHistory).ToArray();
            var sumSeason = SeasonHistory.Sum(_ => _.Value);

            if (sumSeason == 0) return default;

            var coefficients = new List<double>();
            for (var i = 0; i < _season; i++)
            {
                var eachSum = SumEach(SeasonHistory, i, countSeason);
                var coefficient = (eachSum / sumSeason) * 12;
                coefficients.Add(coefficient);
            }

            double SumEach(Data[] seasonHistory, int index, int cntSeason)
            {
                var sum = 0d;
                for (var i = 0; i < cntSeason; i++)
                {
                    sum += SeasonHistory[index + _season * i].Value;
                }
                return sum;
            }

            return coefficients;
        }
    }
}
