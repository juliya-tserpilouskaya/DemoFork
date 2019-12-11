using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.GlobalSearch.Data.Enums
{
    /// <summary>
    /// Contains the values of sections defined for learning courses
    /// </summary>
    public enum Section
    {
        /// <summary>
        /// Indicates that current course includes programming learning materials
        /// </summary>
        Programming = 0,
        /// <summary>
        /// Indicates that current course includes network engeneering learning materials
        /// </summary>
        NetworkEngeneering = 1,
        /// <summary>
        /// Indicates that current course includes mobile app development learning materials
        /// </summary>
        Mobile = 2,
        /// <summary>
        /// Indicates that current course includes game development learning materials
        /// </summary>
        Gamedev = 3,
        /// <summary>
        /// Indicates that current course includes database engeneering learning materials
        /// </summary>
        Databases = 4,
        /// <summary>
        /// Indicates that current course includes graphics design learning materials
        /// </summary>
        Design = 5,
        /// <summary>
        /// Indicates that current course includes user experience and user interface learning materials
        /// </summary>
        UIUX = 6,
        /// <summary>
        /// Indicates that current course includes quality assurance learning materials
        /// </summary>
        QA = 7,
        /// <summary>
        /// Indicates that current course includes technical support learning materials
        /// </summary>
        Support = 9,
        /// <summary>
        /// Indicates that current course includes uncategorized learning materials
        /// </summary>
        Other = 10,
    }
}