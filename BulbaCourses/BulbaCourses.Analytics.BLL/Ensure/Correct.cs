using System.Text.RegularExpressions;

namespace BulbaCourses.Analytics.BLL.Ensure
{
    /// <summary>
    /// Represents correcting string.
    /// </summary>
    public static class Correct
    {
        /// <summary>
        /// Removes double and more space. Trim.
        /// </summary>
        /// <param name="stringToFix"></param>
        /// <returns></returns>
        public static string SpaceFix(this string stringToFix)
        {
            if (string.IsNullOrEmpty(stringToFix)) 
                return stringToFix;

            return Regex.Replace(stringToFix, " {2,}", " ").Trim();
        }
    }
}
