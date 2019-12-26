using System;
using System.IO;
using System.Reflection;

namespace BulbaCourses.Analytics.Web.Ensure
{
    /// <summary>
    /// Represents file paths.
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// Gets Xml Comments File Path 
        /// </summary>
        /// <returns></returns>
        public static string XmlCommentsFilePath
        {
            get
            {
                var appDomain = AppDomain.CurrentDomain;
                var contentRootPath = string.IsNullOrEmpty(appDomain.RelativeSearchPath) ? appDomain.BaseDirectory : appDomain.RelativeSearchPath;

                var fileName = typeof(Global).GetTypeInfo().Assembly.GetName().Name + ".xml";

                return Path.Combine(contentRootPath, fileName);
            }
        }
    }
}