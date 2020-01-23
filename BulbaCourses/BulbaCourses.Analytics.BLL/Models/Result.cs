namespace BulbaCourses.Analytics.Models
{
    /// <summary>
    /// Represents a result value.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Creates a result value.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        protected Result(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        /// <summary>
        /// Gets whether the result was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets whether the result was not successful.
        /// </summary>
        public bool IsError => !IsSuccess;

        /// <summary>
        /// Gets additional information about the result.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets successful result.
        /// </summary>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result(true, null);
        }

        /// <summary>
        /// Gets unsuccessful result with message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Fail(string message)
        {
            return new Result(false, message);
        }
    }

    /// <summary>
    /// Represents generic result value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result where T : class
    {
        /// <summary>
        /// Creates generic Result value.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        protected Result(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }

        /// <summary>
        /// Gets the result data.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets successful generic result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Result<T> Ok<T>(T data) where T : class
        {
            return new Result<T>(true, null, data);
        }

        /// <summary>
        /// Gets unsuccessful generic result with message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<T> Fail<T>(string message) where T : class
        {
            return new Result<T>(false, message, null);
        }
    }
}