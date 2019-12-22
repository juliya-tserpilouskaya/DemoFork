namespace BulbaCourses.Analytics.BLL.Ensure
{
    /// <summary>
    /// Represents search options.
    /// </summary>
    public static class Search
    {
        /// <summary>
        /// Search string option.
        /// </summary>
        public enum StringOption
        {
            /// <summary>
            /// The string equals a search string.
            /// </summary>
            Equals,
            /// <summary>
            /// The string starts with a search string.
            /// </summary>
            StartsWith,
            /// <summary>
            /// The string ends with a search string.
            /// </summary>
            EndsWith,
            /// <summary>
            /// The string contains a search string.
            /// </summary>
            Contains
        }
    }
}
