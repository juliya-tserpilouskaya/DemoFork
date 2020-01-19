using System;
using System.Collections.Generic;
using System.Linq;

namespace Forecast
{
    /// <summary>
    /// Represents a confidential interval for average general set using normal distribution.
    /// </summary>
    public class ConfidenceInterval
    {
        /// <summary>
        /// Creates a confidential interval for average general set using normal distribution.
        /// </summary>
        /// <param name="values"></param>
        public ConfidenceInterval(IEnumerable<double> values)
        {
            ScopeAlfa = 1.96;
            var enumerable = values as double[] ?? values.ToArray();
            CountDateForecast = FuncStat.Count(enumerable);
            StandartDeviation = FuncStat.StandardDeviation(enumerable);
        }

        /// <summary>
        /// Gets significance level used to calculate confidence level.
        /// Number greater than 0 and less than 1.
        /// </summary>
        public double ScopeAlfa { get; }

        /// <summary>
        /// Gets a Count Date Forecast. 
        /// </summary>
        public double CountDateForecast { get; }

        /// <summary>
        /// The set standard deviation for the data interval.
        /// Must be greater than zero.
        /// </summary>
        public double StandartDeviation { get; }

        /// <summary>
        /// Calculate value a confidential interval for average general set using normal distribution.
        /// </summary>
        public void Calculate()
        {
            if (StandartDeviation == default || CountDateForecast == default) Value= default;

                Value = ScopeAlfa * StandartDeviation / Math.Sqrt(CountDateForecast);
        }

        /// <summary>
        /// Gets value a confidential interval for average general set using normal distribution.
        /// </summary>
        public double Value { get; private set; }
    }
}
