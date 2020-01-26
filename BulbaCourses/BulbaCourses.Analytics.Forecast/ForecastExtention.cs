using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <param name="lastValues"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyHistoric(this IEnumerable<ForecastData> data, int lastValues)
        {
            if (lastValues == 0)
            {
                return data.Where(x => x.Value != 0).Select((_) => new Data(_.Date, _.Value));
            }

            var all = data.Where(x => x.Value != 0).ToArray();
            var skipCount = all.Count() - lastValues;

            return
                all.Skip(skipCount).Select((_) => new Data(_.Date, _.Value));
        }

        /// <summary>
        /// Gets only Forecast data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="firstValues"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyForecast(this IEnumerable<ForecastData> data, int firstValues)
        {
            return firstValues == 0 ? data.Where(x => x.Value == 0).Select((_) => new Data(_.Date, _.Forecast ?? 0)) : data.Where(x => x.Value == 0).Take(firstValues).Select((_) => new Data(_.Date, _.Forecast ?? 0));
        }

        /// <summary>
        /// Gets only Forecast Optimistic data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="firstValues"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyForecastOptimistic(this IEnumerable<ForecastData> data, int firstValues)
        {
            return firstValues == 0 ? data.Where(x => x.Value == 0).Select((_) => new Data(_.Date, _.ForecastOptimistic ?? 0)) : data.Where(x => x.Value == 0).Take(firstValues).Select((_) => new Data(_.Date, _.ForecastOptimistic ?? 0));
        }

        /// <summary>
        /// Gets only Forecast Pessimistic data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="firstValues"></param>
        /// <returns></returns>
        public static IEnumerable<Data> GetOnlyForecastPessimistic(this IEnumerable<ForecastData> data, int firstValues)
        {
            return firstValues == 0 ? data.Where(x => x.Value == 0).Select((_) => new Data(_.Date, _.ForecastPessimistic ?? 0)) : data.Where(x => x.Value == 0).Take(firstValues).Select((_) => new Data(_.Date, _.ForecastPessimistic ?? 0));
        }

        /// <summary>
        /// Gets date as string array. Index [0] - date, [1] - value data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string[] ToStringLikeArray(this IEnumerable<Data> data)
        {
            const string BRACKETLEFT = "[";
            const string BRACKETRIGHT = "]";
            const string COMMA = ", ";
            var dateBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();
            dateBuilder.Append(BRACKETLEFT);
            valueBuilder.Append(BRACKETLEFT);
            var enumerable = data as Data[] ?? data.ToArray();
            var count = enumerable.Count();
            for (int i = 0; i < count; i++)
            {
                dateBuilder.Append(enumerable[i].Date.ToString("d"));
                valueBuilder.Append(enumerable[i].Value);
                if (i == (count - 1)) break;
                dateBuilder.Append(COMMA);
                valueBuilder.Append(COMMA);
            }
            dateBuilder.Append(BRACKETRIGHT);
            valueBuilder.Append(BRACKETRIGHT);
            return new[] { dateBuilder.ToString(), valueBuilder.ToString() };
        }
    }
}
