using System;

namespace Forecast
{
    /// <summary>
    /// Represents base forecast data for analytics.
    /// </summary>
    public class ForecastData
    {
        /// <summary>
        /// Represents base forecast data for analytics.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <param name="forecast"></param>
        /// <param name="forecastOptimistic"></param>
        /// <param name="forecastPessimistic"></param>
        public ForecastData(DateTime date, double value, double? forecast, double? forecastOptimistic, double? forecastPessimistic)
        {
            Date = date;
            DateStamp = date.ToOADate();
            Value = value;
            Forecast = forecast;
            ForecastOptimistic = forecastOptimistic;
            ForecastPessimistic = forecastPessimistic;
        }

        /// <summary>
        /// Gets Date.
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// Gets DateStamp.
        /// </summary>
        public double DateStamp { get; }

        /// <summary>
        /// Gets Value.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// Gets forecast.
        /// </summary>
        public double? Forecast { get; }

        /// <summary>
        /// Gets an optimistic forecast.
        /// </summary>
        public double? ForecastOptimistic { get; set; }

        /// <summary>
        /// Gets a pessimistic forecast.
        /// </summary>
        public double? ForecastPessimistic { get; set; }

    }
}
