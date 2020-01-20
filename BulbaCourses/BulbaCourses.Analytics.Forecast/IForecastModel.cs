using System.Collections.Generic;

namespace Forecast
{
    /// <summary>
    /// Interface for Model Data.
    /// </summary>
    public interface IForecastModel
    {
        /// <summary>
        /// Forecast Data.
        /// Function: y = a + bx
        /// </summary>
        /// <returns></returns>
        IEnumerable<ForecastData> GetData();
    }
}