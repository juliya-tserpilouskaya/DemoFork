using BulbaCourses.Analytics.BLL.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Infrastructure
{
    internal static class ThrowException
    {
        internal static void IsNull(string Id, string Message)
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new NotFoundException(Message, nameof(Id));
        }

        internal static void IsNull(object Obj, string Message)
        {
            if (Obj == null)
                throw new NotFoundException(Message, nameof(Obj));
        }

        internal static void IsEmty(bool Value, string Message)
        {
            if (Value)
                throw new NotFoundException(Message);
        }
    }
}
