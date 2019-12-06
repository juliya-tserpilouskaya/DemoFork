using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.Analytics.BLL.Infrastructure.Exceptions
{
    internal static class ExceptionMessage
    {
        internal static string GetMessage(string message, string property)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                return message;
            }

            return string.Format("{0} [{1}]", message, property);
        }
    }
}
