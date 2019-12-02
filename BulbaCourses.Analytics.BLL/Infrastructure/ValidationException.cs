using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    /// <summary>
    /// Represents errors an invalid Property and Message
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Provides exceptions an invalid Property and Message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="prop"></param>
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }

        /// <summary>
        /// Name of invalid Property
        /// </summary>
        public string Property { get; protected set; }
    }
}
