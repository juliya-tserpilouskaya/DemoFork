using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Data.Enums
{
    /// <summary>
    /// Contains the values of categories defined for learning items
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Indicates that current item belongs to a video course
        /// </summary>
        Video = 0,
        /// <summary>
        /// Indicates that current item belongs to a podcast course
        /// </summary>
        Podcast = 1,
        /// <summary>
        /// Indicates that current item belongs to a theorethical course
        /// </summary>
        Text = 2,
        /// <summary>
        /// Indicates that current item belongs to a practical course and includes tests
        /// </summary>
        Excercise = 3,
        /// <summary>
        /// Indicates that current item belongs to a practical course includes tests
        /// </summary>
        Test = 4,
        /// <summary>
        /// Indicates that current item belongs to an uncategorized course
        /// </summary>
        Other = 5,
    }
}