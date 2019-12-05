using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Infrastructure.Exceptions
{    
    public abstract class AbstractException : Exception
    {
        protected AbstractException(string message, string property) :
            base(ExceptionMessage.GetMessage(message, property))
        {
        }

        protected AbstractException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AbstractException()
        {
        }

        protected AbstractException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
