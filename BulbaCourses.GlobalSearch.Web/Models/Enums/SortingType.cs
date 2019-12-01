using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Web.Models.Enums
{
    public enum SortingType
    {
        Popularity = 0,
        PriceLowToHigh = 1,
        PriceHighToLow = 2,
        DateNewFirst = 3,
        DateOldFirst = 4,
        Sales = 5,
    }
}