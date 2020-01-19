using System.Collections.Generic;
using System.Linq;

namespace Forecast
{
    /// <summary>
    /// Represents Forecast Extention.
    /// </summary>
    public static class ForecastExtention
    {
        /// <summary>
        /// Gets only Historic data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyHistoric(this IEnumerable<ForecastData> data)
        {
            return data.Where(x => x.Value != 0).Select((_) => new Data(_.Date, _.Value));
        }

        /// <summary>
        /// Gets only Forecast data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyForecast(this IEnumerable<ForecastData> data)
        {
            return data.Where(x => x.Value == 0).Select((_) => new Data(_.Date, _.Forecast ?? 0));
        }

        /// <summary>
        /// Gets only Forecast Optimistic data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyForecastOptimistic(this IEnumerable<ForecastData> data)
        {
            return data.Where(x => x.Value == 0).Select((_) => new Data(_.Date, _.ForecastOptimistic ?? 0));
        }

        /// <summary>
        /// Gets only Forecast Pessimistic data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyForecastPessimistic(this IEnumerable<ForecastData> data)
        {
            return data.Where(x => x.Value == 0).Select((_) => new Data(_.Date, _.ForecastPessimistic ?? 0));
        }
    }
}
