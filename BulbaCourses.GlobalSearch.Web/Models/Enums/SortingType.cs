using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models.Enums
{
    /// <summary>
    /// Contains the values of sorting types defined for learning courses
    /// </summary>
    public enum SortingType
    {
        /// <summary>
        /// Indicates that learning courses should be ordered
        /// by popularity - from the most to the least popular
        /// </summary>
        Popularity = 0,
        /// <summary>
        /// Indicates that learning courses should be ordered
        /// by price - from the most to the least cheap
        /// </summary>
        PriceLowToHigh = 1,
        /// <summary>
        /// Indicates that learning courses should be ordered
        /// by price - from the most to the least expensive
        /// </summary>
        PriceHighToLow = 2,
        /// <summary>
        /// Indicates that learning courses should be ordered
        /// by date - from the newest to the oldest
        /// </summary>
        DateNewFirst = 3,
        /// <summary>
        /// Indicates that learning courses should be ordered
        /// by date - from the oldest to the newest
        /// </summary>
        DateOldFirst = 4,
    }
}