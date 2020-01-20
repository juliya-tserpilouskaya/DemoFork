using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Podcasts.Logic.Models
{
    public class Result
    {
        protected Result(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public bool IsSuccess { get; }

        public bool IsError => !IsSuccess;

        public string Message { get; }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }
    }

    public class Result<T> : Result where T : class
    {
        protected Result(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }

        public static Result<T> Ok(T data)
        {
            return new Result<T>(true, null, data);
        }

        public new static Result<T> Fail(string message)
        {
            return new Result<T>(false, message, null);
        }
    }

}
