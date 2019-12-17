using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Data.Enums
{
    /// <summary>
    /// Contains the values of complexity level defined for learning courses
    /// </summary>
    public enum Complexity
    {
        /// <summary>
        /// Indicates that current course is intended for a person new to programming
        /// </summary>
        Beginner = 0,
        /// <summary>
        /// Indicates that current course is intended for an experienced person
        /// </summary>
        Advanced = 1,
        /// <summary>
        /// Indicates that current course is intended for a professional
        /// </summary>
        Professional = 2,
    }
}