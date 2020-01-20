using System;

namespace Forecast
{
    /// <summary>
    /// Represents base data for analytics.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Represents base data for analytics.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        public Data(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        /// <summary>
        /// Gets Date.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Gets Value.
        /// </summary>
        public double Value { get; }
    }
}
