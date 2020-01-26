using System;

namespace BulbaCourses.PracticalMaterialsTests.Logic.Models.Base
{
    public class MResultRequest
    {
        protected MResultRequest(bool success, string message)
        {
            IsSuccess = success;

            Message = message;
        }

        public bool IsSuccess { get; }

        public bool IsError => !IsSuccess;

        public string Message { get; }

        public static MResultRequest Ok()
        {
            return 
                new MResultRequest(true, null);
        }

        public static MResultRequest Fail(string message)
        {
            return 
                new MResultRequest(false, message);
        }
    }

    public class MResultRequest<T> : MResultRequest where T : class
    {
        protected MResultRequest(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }

        public static MResultRequest<T> Ok<T>(T data) where T : class
        {
            return 
                new MResultRequest<T>(true, null, data);
        }

        public static MResultRequest Fail<T>(string message) where T : class
        {
            return 
                new MResultRequest<T>(false, message, null);
        }
    }
}
