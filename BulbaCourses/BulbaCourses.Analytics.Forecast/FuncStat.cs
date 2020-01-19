using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqStatistics;

namespace Forecast
{
    /// <summary>
    /// Represents statistical functions.
    /// </summary>
    public static class FuncStat
    {
        /// <summary>
        /// Gets a Count of elements in a sequence.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int Count(IEnumerable<double> values)
        {
            var enumerable = values as double[] ?? values.ToArray();
            return !enumerable.Any() ? default : enumerable.Count();
        }

        /// <summary>
        /// Computes the sample StandardDeviation of a sequence of double values.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double StandardDeviation(IEnumerable<double> values)
        {
            var enumerable = values as double[] ?? values.ToArray();
            return !enumerable.Any() ? default : enumerable.StandardDeviation();
        }
    }
}
